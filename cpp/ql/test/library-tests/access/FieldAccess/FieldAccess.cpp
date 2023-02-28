typedef int I;
typedef I* P;

struct D {
  int *p1;
  P p2;

  D() : p1(new int), p2(new int) {}

  virtual ~D() {
    delete p1;
    delete p2;
  }
};

struct S {
  D d;
  int x1;
  I x2;

  int get1() {
    // This looks like an implicit access of `this->x1`, but it is
    // apparently automatically converted to `this->x1` by the frontend, so it
    // comes out as a `PointerFieldAccess`.
    return x1;
  }

  int get2() {
    return this->x2;
  }

  virtual ~S() {
    // Implicit access of `d`, to call its destructor.
  }
};

typedef S ST;

union U {
  int x;
  double d;
};

int test_ptr00(S *s) {
  return s->x1;
}

int test_ptr01(S *s) {
  return *(s->d.p1);
}

int test_ptr02(ST *s) {
  return s->x2;
}

int test_ptr03(ST *s) {
  return *(s->d.p2);
}

int test_ptr04(U *u) {
  return u->x;
}

int test_ref00(S &s) {
  return s.x1;
}

int test_ref01(S &s) {
  return s.x2;
}

int test_ref02(U &u) {
  return u.x;
}

int test_ref03(S &&s) {
  return s.x1;
}

int test_val00(S s) {
  return s.x1;
}

int test_val01(U u) {
  return u.x;
}
