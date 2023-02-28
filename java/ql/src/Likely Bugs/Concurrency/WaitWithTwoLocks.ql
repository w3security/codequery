/**
 * @name Wait with two locks held
 * @description Calling 'Object.wait' while two locks are held may cause deadlock.
 * @kind problem
 * @problem.severity error
 * @precision low
 * @id java/wait-with-two-locks
 * @tags reliability
 *       correctness
 *       concurrency
 *       external/cwe/cwe-833
 */

import java

/** A `synchronized` method or statement. */
class Synched extends StmtParent {
  Synched() {
    this.(Method).isSynchronized() or
    this instanceof SynchronizedStmt
  }
}

from MethodAccess ma, SynchronizedStmt synch
where
  ma.getMethod().hasName("wait") and
  ma.getMethod().getDeclaringType().hasQualifiedName("java.lang", "Object") and
  ma.getEnclosingStmt().getParent*() = synch and
  synch.getParent+() instanceof Synched
select ma, "wait() with two locks held."
