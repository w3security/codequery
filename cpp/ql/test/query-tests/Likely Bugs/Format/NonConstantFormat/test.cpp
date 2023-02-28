extern "C" int printf(const char *fmt, ...);
extern "C" int sprintf(char *buf, const char *fmt, ...);
extern "C" char *gettext (const char *);

bool gettext_debug = false;

const char *messages[] = {
    "All tasks done\n",
    "One task left\n",
    "%u tasks left\n",
};

const char *choose_message(unsigned int n) {
  if (n == 0) {
    const char *message = messages[0];
    return message;
  } else {
    return n == 1
         ? messages[n]
         : messages[sizeof messages / sizeof *messages - 1];
  }
}

const char *make_message(unsigned int n) {
  static char buf[64];
  sprintf(buf, "%d tasks left\n", n);
  return buf;
}

// This is meant to simulate a typical gettext wrapper function
const char *_(const char *str) {
  if (gettext_debug) {
    return "#";
  }
  return str ? gettext(str) : "NULL";
}

// Attempt to "const-wash" a non-const string. Should be detected.
const char *const_wash(char *str) {
  return str;
}

int main(int argc, char **argv) {
  printf(choose_message(argc - 1), argc - 1); // OK
  printf(make_message(argc - 1)); // NOT OK
  printf(_("Hello, World\n")); // OK
  {
    char hello[] = "hello, World\n";
    hello[0] = 'H';
    printf(hello); // NOT OK
    printf(_(hello)); // NOT OK
    printf(gettext(hello)); // NOT OK
    printf(const_wash(hello)); // NOT OK
    printf((hello + 1) + 1); // NOT OK
    printf(+hello); // NOT OK
    printf(*&hello); // NOT OK
    printf(&*hello); // NOT OK
    printf((char*)(void*)+(hello+1) + 1); // NOT OK
  }
  printf(("Hello, World\n" + 1) + 1); // NOT OK
  {
    const char *hello = "Hello, World\n";
    printf(hello + 1); // NOT OK
    printf(hello); // OK
  }
  {
    const char *hello = "Hello, World\n";
    hello += 1;
    printf(hello); // NOT OK
  }
  {
    // Same as above block but using "x = x + 1" syntax
    const char *hello = "Hello, World\n";
    hello = hello + 1;
    printf(hello); // NOT OK
  }
  {
    // Same as above block but using "x++" syntax
    const char *hello = "Hello, World\n";
    hello++;
    printf(hello); // NOT OK
  }
  {
    // Same as above block but using "++x" as subexpression
    const char *hello = "Hello, World\n";
    printf(++hello); // NOT OK
  }
  {
    // Same as above block but through a pointer
    const char *hello = "Hello, World\n";
    const char **p = &hello;
    (*p)++;
    printf(hello); // NOT OK
  }
  {
    // Same as above block but through a C++ reference
    const char *hello = "Hello, World\n";
    const char *&p = hello;
    p++;
    printf(hello); // NOT OK
  }
  if (gettext_debug) {
    printf(new char[100]); // NOT OK
  }
  {
    const char *hello = "Hello, World\n";
    const char *const *p = &hello; // harmless reference to const pointer
    printf(hello); // OK [FALSE POSITIVE]
    hello++; // modification comes after use and so does no harm
  }
  printf(argc > 2 ? "More than one\n" : _("Only one\n")); // OK

  // This false positive arises because we use const_wash in a problematic
  // place at one call site, and then the error spreads to all call sites. It
  // does not happen for "_" only because functions with the name "_" are
  // special-cased and assumed correct in the query.
  printf(const_wash("Hello, World\n")); // OK [FALSE POSITIVE]
}
