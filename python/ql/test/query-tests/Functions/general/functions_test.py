
#Consistent Returns

__all__ = [ '' ]

def ok1(x):
    if x:
        return None
    else:
        return

def ok2(x):
    if x:
        return 4
    else:
        return "Hi"

def cr1(x):
    if x:
        return 4

def cr2(x):
    if x:
        return 4
    else:
        return
    
def ok3(x):
    try:
        return
    finally:
        do_something()

#Modification of parameter with default

def ok4(x = []):
    return len(x)

def mpd(x = []):
    x.append("x")

class ExplicitReturnInInit(object):

    def __init__(self):
        return self
        
#These are OK
class ExplicitReturnNoneInInit(object):

    def __init__(self):
        return None

class PlainReturnInInit(object):

    def __init__(self):
        return
    
def error():
    raise Exception()
    
class InitCallsError(object):

    def __init__(self):
        return error()
    
class InitCallsInit(InitCallsError):

    def __init__(self):
        return InitCallsError.__init__(self)

class InitIsGenerator(object):

    def __init__(self):
        yield self

def use_implicit_return_value(arg):
    x = do_nothing()
    return call_non_callable(arg)

#The return in the lambda is OK as it is auto-generated
y = lambda x : do_nothing()

def do_nothing():
    pass

#Using name other than 'cls' for first parameter in methods.
# This shouldn't apply to classmethods (first parameter should be 'cls' or similar)
# or static methods (first parameter can be anything)

class Normal(object):

    def n_ok(self):
        pass

    @staticmethod
    def n_smethod(ok):
        pass

    @classmethod
    def n_cmethod(self):
        pass

    # this is allowed because it has a decorator other than @classmethod
    @classmethod
    @id
    def n_suppress(any_name):
        pass

class Class(type):

    def __init__(cls):
        pass

    def c_method(y):
        pass

    def c_ok(cls):
        pass

    @id
    def c_suppress(any_name):
        pass

#Using name other than 'self' for first parameter in methods.
# This shouldn't apply to classmethods (first parameter should be 'cls' or similar)
# or static methods (first parameter can be anything)

class NonSelf(object):

    def __init__(x):
        pass

    def s_method(y):
        pass

    def s_ok(self):
        pass

    @staticmethod
    def s_smethod(ok):
        pass

    @classmethod
    def s_cmethod(cls):
        pass

    def s_smethod2(ok):
        pass
    s_smethod2 = staticmethod(s_smethod2)

    def s_cmethod2(cls):
        pass
    s_cmethod2 = classmethod(s_cmethod2)

def returns_self(self):
    return self

def return_value_ignored():
    ok2()
    ok4()
    sorted([1,2])
    
d = {}
 
def use_return_values():
    x = ok2()
    x = ok2()
    x = ok3()
    x = ok3()
    x = ok4()
    x = ok4()
    x = y()
    x = y()
    x = returns_self()
    x = returns_self()
    x = sorted(x)
    x = sorted(x)
    x = ok2()
    x = ok2()
    x = ok3()
    x = ok3()
    x = ok4()
    x = ok4()
    x = y()
    x = y()
    x = returns_self()
    x = returns_self()
    x = sorted(x)
    x = sorted(x)

def ok_to_ignore():
    ok1
    do_nothing()
    returns_self()
    ok3()
    y()
    
class DeprecatedSliceMethods(object):
    
    def __getslice__(self, start, stop):
        pass
    
    def __setslice__(self, start, stop, value):
        pass
    
    def __delslice__(self, start, stop):
        pass



@decorator
def nested_call_implicit_return_func_ok(arg):
    do_nothing()






#OK as it returns result of a call to super().__init__()
class InitCallsInit(InitCallsError):

    def __init__(self):
        return super(InitCallsInit, self).__init__()
    
#Harmless, so we allow it.
def use_implicit_return_value_ok(arg):
    return do_nothing()
   
def mutli_return(arg):
    if arg:
        return do_something()
    else:
        return do_nothing()
    
#Modification of parameter with default

def augassign(x = []):
    x += ["x"]
    
    
#Possible FPs for non-self. ODASA-2439

class C(object):
    def _func(f):
        return f
  
    _func(x)
    
    #or
    @_func
    def meth(self):
        pass


def dont_care(arg):
    pass

class C(object):

    meth = dont_care

class Meta(type):

    #__new__ is an implicit class method, so the first arg is the metaclass
    def __new__(metacls, name, bases, cls_dict):
        return super(Meta, metacls).__new__(metacls, name, bases, cls_dict)

#ODASA 3658
from sys import exit
#Consistent returns
def ok5():
    try:
        may_raise()
        return 0
    except ValueError as e:
        print(e)
        exit(EXIT_ERROR)

#ODASA-6062
import zope.interface
class Z(zope.interface.Interface):

    def meth(arg):
        pass

Z().meth(0)

