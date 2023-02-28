
typedef enum {
	MYONETHOUSAND = 1000
} myenum;

typedef int MYINT;

void f(char *s, int i, unsigned char *us, const char *cs, signed char *ss, char c, MYINT mi, unsigned long long ull) {
    const char cc = 'x';

    printf("%s: %d\n", s, i);      // ok
    printf("%s: %f\n", s, i);      // not ok (int -> float)
    printf("%s", us);              // ok
    printf("%s", cs);              // ok
    printf("%s", ss);              // ok

    printf("%p", cs);              // ok
    printf("%p", i);               // not ok (int -> void *)
    printf("%p", &f);              // ok

    printf("%*s", i, cs);          // ok
    printf("%*s", mi, cs);         // ok
    printf("%*s", c, cs);          // ok
    printf("%*s", cc, cs);         // ok
    printf("%*s", i, i);           // not ok (int -> char *)
    printf("%d %% %*s", i, i, cs); // ok
    printf("%*s", cs, cs);         // not ok (the width argument should be integer)

    printf("%c", 10);              // ok
    printf("%c", 1000);            // not ok [NOT DETECTED]
    printf("%wc", 10);             // ok
    printf("%wc", 1000);           // ok
    printf("%u", -1);              // not ok [NOT DETECTED]
    printf("%u", 10);              // ok
    printf("%u", 1000);            // ok

    printf("%i", MYONETHOUSAND);     // ok
    printf("%s", MYONETHOUSAND);     // not ok (enum -> char *)
    printf("%c", MYONETHOUSAND);     // not ok (enum -> char) [NOT DETECTED]

    printf("%i", mi);                // ok
    printf("%u", mi);                // not ok (int -> unsigned int) [NOT DETECTED]

    printf("%d", ull);               // not ok (unsigned long long -> int)
    printf("%u", ull);               // not ok (unsigned long long -> unsigned int)
    printf("%x", ull);               // not ok (unsigned long long -> unsigned int)
    printf("%Lx", ull);              // not ok (unsigned long long -> unsigned int)
    printf("%llx", ull);             // ok
}

typedef size_t SIZE_T;

void g()
{
    unsigned long ul;
    size_t st;
    SIZE_T ST;
    const size_t c_st = sizeof(st);
    const SIZE_T C_ST = sizeof(st);
    ssize_t sst;

    printf("%zu", ul); // ok (dubious, e.g. on 64-bit Windows `long` is 4 bytes but `size_t` is 8)
    printf("%zu", st); // ok
    printf("%zu", ST); // ok
    printf("%zu", c_st); // ok
    printf("%zu", C_ST); // ok
    printf("%zu", sizeof(ul)); // ok
    printf("%zu", sst); // not ok [NOT DETECTED]

    printf("%zd", ul); // not ok [NOT DETECTED]
    printf("%zd", st); // not ok [NOT DETECTED]
    printf("%zd", ST); // not ok [NOT DETECTED]
    printf("%zd", c_st); // not ok [NOT DETECTED]
    printf("%zd", C_ST); // not ok [NOT DETECTED]
    printf("%zd", sizeof(ul)); // not ok [NOT DETECTED]
    printf("%zd", sst); // ok
    {
        char *ptr_a, *ptr_b;
        char buf[100];

        printf("%tu", ptr_a - ptr_b); // ok
        printf("%td", ptr_a - ptr_b); // ok
        printf("%zu", ptr_a - ptr_b); // ok (dubious)
        printf("%zd", ptr_a - ptr_b); // ok (dubious)
    }
}

void h(int i, struct some_type *j, int k)
{
	// %R is a made-up format symbol, to simulate something obscure that we don't
	// recognize.  We should not report a problem if we're unable to understand what's
	// going on.
	printf("%i %R %i", i, j, k); // GOOD (as far as we can tell)
}

typedef long ptrdiff_t;

void fun1(unsigned char* a, unsigned char* b) {
  ptrdiff_t pdt;

  printf("%td\n", pdt); // GOOD
  printf("%td\n", a-b); // GOOD
}
