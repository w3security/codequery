// Semmle test cases for rule CWE-457.

void use(int data);

void test1() {
	int foo = 1;
	use(foo); // GOOD
}

void test2() {
	int foo;
	use(foo); // BAD
}

void test3(bool b) {
	int foo;
	if (b) {
		foo = 1;
	} else {
		foo = 2;
	}
	use(foo); // GOOD
}

void test4(bool b) {
	int foo;
	if (b) {
		foo = 1;
	}
	use(foo); // BAD
}

void test5() {
	int foo;
	for (int i = 0; i < 10; i++) {
		foo = i;
	}
	use(foo); // GOOD
}

void test5(int count) {
	int foo;
	for (int i = 0; i < count; i++) {
		foo = i;
	}
	use(foo); // BAD
}

void test6(bool b) {
	int foo;
	if (b) {
		foo = 42;
	}
	if (b) {
		use(foo); // GOOD (REPORTED, FP)
	}
}

void test7(bool b) {
	bool set = false;
	int foo;
	if (b) {
		foo = 42;
		set = true;
	}
	if (set) {
		use(foo); // GOOD (REPORTED, FP)
	}
}

void test8() {
	int foo;
	int count = 1;
	while (count > 0) {
		foo = 42;
		count--;
	}
	use(foo); // GOOD
}

void test9(int count) {
	int foo;
	bool set = false;
	while (count > 0) {
		foo = 42;
		set = true;
		count--;
	}
	if (!set) {
		foo = 42;
	}
	use(foo); // GOOD (REPORTED, FP)
}

void test10() {
	extern int i;
	use(i); // GOOD
}

void test11() {
	static int i;
	use(i); // GOOD
}

void test12() {
	static int i[10];
	use(i[0]); // GOOD
}

void test13() {
	int foo;
	&foo;
	use(foo); // BAD
}

void init(int* p) { *p = 1; }

void test14() {
	int foo;
	init(&foo);
	use(foo); // GOOD
}

// Example from qhelp
int absWrong(int i) {
	int j;
	if (i > 0) {
		j = i;
	} else if (i < 0) {
		j = -i;
	}
	return j; // wrong: j may not be initialized before use
}

// Example from qhelp
int absCorrect1(int i) {
	int j = 0;
	if (i > 0) {
		j = i;
	} else if (i < 0) {
		j = -i;
	}
	return j; // correct: j always initialized before use
}

// Example from qhelp
int absCorrect2(int i) {
	int j;
	if (i > 0) {
		j = i;
	} else if (i < 0) {
		j = -i;
	} else {
		j = 0;
	}
	return j; // correct: j always initialized before use
}


typedef void *va_list;
#define va_start(ap, parmN)
#define va_end(ap)
#define va_arg(ap, type) ((type)0)
#define NULL 0

// Variadic initialisation
void init(int val, ...) {
  int* ptr;
  va_list args;
  va_start(args, val);
  while ((ptr = va_arg(args, int*)) != NULL) {
    *ptr = val;
  }
}

void test15() {
  int foo;
  init(42, &foo, NULL);
  use(foo); //GOOD -- initialised by `init`
}

// Variadic non-initialisation
void nonInit(int val, ...) {
  int* ptr;
  va_list args;
  va_start(args, val);
}

void test16() {
  int foo;
  nonInit(42, &foo, NULL);
  use(foo); // BAD (NOT REPORTED)
}

bool test17(bool b) {
  int foo;
  int *p = nullptr;
  if (b) {
    p = &foo;
  }
  return p == &foo; // GOOD -- value of `foo` ignored
}

void test18() {
  int x;
  *&x = 1;
  use(x); // GOOD
}

void test19() {
  int x;
  ((char*)(void*)&x)[0] = 0;
  use(x); // GOOD, conservatively assuming only the first byte is needed
}


void test20() {
  int x;
  x += 0; // BAD
  use(x);
}

class MyValue {
public:
	MyValue() {};
	MyValue(int _val) : val(_val) {};

	MyValue operator>>(int amount)
	{
		return MyValue(val >> amount);
	}

	int val;
};

void test21()
{
	MyValue v1(1);
	MyValue v2;
	MyValue v3;
	int i;

	v3 = v1 >> i; // BAD: i is not initialized
	v3 = v2 >> 1; // BAD: v2 is not initialized [NOT DETECTED]
}