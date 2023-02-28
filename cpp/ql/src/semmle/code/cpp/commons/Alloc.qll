import cpp

/**
 * A library routine that allocates memory.
 */
predicate allocationFunction(Function f)
{
  exists(string name |
    f.hasQualifiedName(name) and
    (
      name = "malloc" or
      name = "calloc" or
      name = "realloc" or
      name = "strdup" or
      name = "wcsdup" or
      name = "_strdup" or
      name = "_wcsdup" or
      name = "_mbsdup" or
      name = "ExAllocatePool" or
      name = "ExAllocatePoolWithTag" or
      name = "ExAllocatePoolWithTagPriority" or
      name = "ExAllocatePoolWithQuota" or
      name = "ExAllocatePoolWithQuotaTag" or
      name = "ExAllocateFromLookasideListEx" or
      name = "ExAllocateFromPagedLookasideList" or
      name = "ExAllocateFromNPagedLookasideList" or
      name = "ExAllocateTimer" or
      name = "IoAllocateMdl" or
      name = "IoAllocateWorkItem" or
      name = "IoAllocateErrorLogEntry" or
      name = "MmAllocateContiguousMemory" or
      name = "MmAllocateContiguousNodeMemory" or
      name = "MmAllocateContiguousMemorySpecifyCache" or
      name = "MmAllocateContiguousMemorySpecifyCacheNode" or
      name = "MmAllocateNonCachedMemory" or
      name = "MmAllocateMappingAddress" or
      name = "MmAllocatePagesForMdl" or
      name = "MmAllocatePagesForMdlEx" or
      name = "MmAllocateNodePagesForMdlEx" or
      name = "MmMapLockedPagesWithReservedMapping" or
      name = "MmMapLockedPages" or
      name = "MmMapLockedPagesSpecifyCache"
    )
  )
}

/**
 * A call to a library routine that allocates memory.
 */
predicate allocationCall(FunctionCall fc)
{
  allocationFunction(fc.getTarget()) and
  (
    // realloc(ptr, 0) only frees the pointer
    fc.getTarget().hasQualifiedName("realloc") implies
    not fc.getArgument(1).getValue() = "0"
  )
}

/**
 * A library routine that frees memory.
 */
predicate freeFunction(Function f, int argNum)
{
  exists(string name |
    f.hasQualifiedName(name) and
    (
      (name = "free" and argNum = 0) or
      (name = "realloc" and argNum = 0) or
      (name = "ExFreePoolWithTag" and argNum = 0) or
      (name = "ExFreeToLookasideListEx" and argNum = 1) or
      (name = "ExFreeToPagedLookasideList" and argNum = 1) or
      (name = "ExFreeToNPagedLookasideList" and argNum = 1) or
      (name = "ExDeleteTimer" and argNum = 0) or
      (name = "IoFreeMdl" and argNum = 0) or
      (name = "IoFreeWorkItem" and argNum = 0) or
      (name = "IoFreeErrorLogEntry" and argNum = 0) or
      (name = "MmFreeContiguousMemory" and argNum = 0) or
      (name = "MmFreeContiguousMemorySpecifyCache" and argNum = 0) or
      (name = "MmFreeNonCachedMemory" and argNum = 0) or
      (name = "MmFreeMappingAddress" and argNum = 0) or
      (name = "MmFreePagesFromMdl" and argNum = 0) or
      (name = "MmUnmapReservedMapping" and argNum = 0) or
      (name = "MmUnmapLockedPages" and argNum = 0)
    )
  )
}

/**
 * A call to a library routine that frees memory.
 */
predicate freeCall(FunctionCall fc, Expr arg)
{
  exists(int argNum |
    freeFunction(fc.getTarget(), argNum) and
    arg = fc.getArgument(argNum)
  )
}

/**
 * Is e some kind of allocation or deallocation (`new`, `alloc`, `realloc`, `delete`, `free` etc)?
 */
predicate isMemoryManagementExpr(Expr e) {
  isAllocationExpr(e) or isDeallocationExpr(e)
}

/**
 * Is e an allocation from stdlib.h (`malloc`, `realloc` etc)?
 */
predicate isStdLibAllocationExpr(Expr e)
{
  allocationCall(e)
}

/**
 * Is e some kind of allocation (`new`, `alloc`, `realloc` etc)?
 */
predicate isAllocationExpr(Expr e) {
  allocationCall(e)
  or
  e = any(NewOrNewArrayExpr new | not exists(new.getPlacementPointer()))
}

/**
 * Is e some kind of allocation (`new`, `alloc`, `realloc` etc) with a fixed size?
 */
predicate isFixedSizeAllocationExpr(Expr allocExpr, int size) {
exists (FunctionCall fc, string name | fc = allocExpr and name = fc.getTarget().getName() |
  (
      name = "malloc" and
      size = fc.getArgument(0).getValue().toInt()
    ) or (
      name = "alloca" and
      size = fc.getArgument(0).getValue().toInt()
    ) or (
      name = "calloc" and
      size = fc.getArgument(0).getValue().toInt() * fc.getArgument(1).getValue().toInt()
    ) or (
      name = "realloc" and
      size = fc.getArgument(1).getValue().toInt() and
      size > 0 // realloc(ptr, 0) only frees the pointer
    )
  ) or (
    size = allocExpr.(NewExpr).getAllocatedType().getSize()
  ) or (
    size = allocExpr.(NewArrayExpr).getAllocatedType().getSize()
  )
}

/**
 * Is e some kind of deallocation (`delete`, `free`, `realloc` etc)?
 */
predicate isDeallocationExpr(Expr e) {
  freeCall(e, _)
  or e instanceof DeleteExpr
  or e instanceof DeleteArrayExpr
}
