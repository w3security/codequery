import python
import semmle.python.security.injection.Sql

/** A taint kind representing a django cursor object.
 */
class DjangoDbCursor extends DbCursor {

    DjangoDbCursor() {
        this = "django.db.connection.cursor"
    }

}

private Object theDjangoConnectionObject() {
    any(ModuleObject m | m.getName() = "django.db").getAttribute("connection") = result
}

/** A kind of taint source representing sources of django cursor objects.
 */
class DjangoDbCursorSource extends DbConnectionSource {

    DjangoDbCursorSource() {
        exists(AttrNode cursor |
            this.(CallNode).getFunction()= cursor and
            cursor.getObject("cursor").refersTo(theDjangoConnectionObject())
        )
    }

    override string toString() {
        result = "django.db.connection.cursor"
    }

    override predicate isSourceOf(TaintKind kind) {
        kind instanceof DjangoDbCursor
    }

}


ClassObject theDjangoRawSqlClass() {
    result = any(ModuleObject m | m.getName() = "django.db.models.expressions").getAttribute("RawSQL")
}

/**
 * A sink of taint on calls to `django.db.models.expressions.RawSQL`. This
 * allows arbitrary SQL statements to be executed, which is a security risk.
 */

class DjangoRawSqlSink extends TaintSink {
    DjangoRawSqlSink() {
        exists(CallNode call |
            call = theDjangoRawSqlClass().getACall() and
            this = call.getArg(0)
        )
    }

    override predicate sinks(TaintKind kind) {
        kind instanceof ExternalStringKind
    }

    override string toString() {
        result = "django.db.models.expressions.RawSQL(sink,...)"
    }
}

