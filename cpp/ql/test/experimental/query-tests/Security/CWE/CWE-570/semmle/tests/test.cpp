#define NULL ((void *)0)

namespace std {
struct nothrow_t {};
typedef unsigned long size_t;

class exception {};
class bad_alloc : public exception {};

extern const std::nothrow_t nothrow;
} // namespace std

using namespace std;

void *operator new(std::size_t);
void *operator new[](std::size_t);
void *operator new(std::size_t, const std::nothrow_t &) noexcept;
void *operator new[](std::size_t, const std::nothrow_t &) noexcept;

void bad_new_in_condition() {
  if (!(new int)) { // BAD [NOT DETECTED]
    return;
  }
}

void foo(int**);

void bad_new_missing_exception_handling() {
  int *p1 = new int[100]; // BAD
  if (p1 == 0)
    return;

  int *p2 = new int[100]; // BAD [NOT DETECTED]
  if (!p2)
    return;

  int *p3 = new int[100]; // BAD
  if (p3 == NULL)
    return;

  int *p4 = new int[100]; // BAD
  if (p4 == nullptr)
    return;

  int *p5 = new int[100]; // BAD [NOT DETECTED]
  if (p5) {} else return;

  int *p6;
  p6 = new int[100]; // BAD
  if (p6 == 0) return;

  int *p7;
  p7 = new int[100]; // BAD [NOT DETECTED]
  if (!p7)
    return;

  int *p8;
  p8 = new int[100]; // BAD
  if (p8 == NULL)
    return;

  int *p9;
  p9 = new int[100]; // BAD
  if (p9 != nullptr) {
  } else
    return;

  int *p10;
  p10 = new int[100]; // BAD [NOT DETECTED]
  if (p10 != 0) {
  }

  int *p11;
  do {
    p11 = new int[100]; // BAD [NOT DETECTED]
  } while (!p11);

  int* p12 = new int[100];
  foo(&p12);
  if(p12) {} else return; // GOOD: p12 is probably modified in foo, so it's
                          // not the return value of the new that's checked.

  int* p13 = new int[100];
  foo(&p13);
  if(!p13) {
      return;
  } else { }; // GOOD: same as above.
}

void bad_new_nothrow_in_exception_body() {
  try {
    new (std::nothrow) int[100];           // BAD
    int *p1 = new (std::nothrow) int[100]; // BAD

    int *p2;
    p2 = new (std::nothrow) int[100]; // BAD
  } catch (const std::bad_alloc &) {
  }
}

void good_new_has_exception_handling() {
  try {
    int *p1 = new int[100]; // GOOD
  } catch (...) {
  }
}

void good_new_handles_nullptr() {
  int *p1 = new (std::nothrow) int[100]; // GOOD
  if (p1 == nullptr)
    return;

  int *p2;
  p2 = new (std::nothrow) int[100]; // GOOD
  if (p2 == nullptr)
    return;

  int *p3;
  p3 = new (std::nothrow) int[100]; // GOOD
  if (p3 != nullptr) {
  }

  int *p4;
  p4 = new (std::nothrow) int[100]; // GOOD
  if (p4) {
  } else
    return;

  int *p5;
  p5 = new (std::nothrow) int[100]; // GOOD
  if (p5 != nullptr) {
  } else
    return;

  if (new (std::nothrow) int[100] == nullptr)
    return; // GOOD
}
