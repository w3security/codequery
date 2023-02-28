Java framework & library support
================================

.. csv-table::
   :header-rows: 1
   :class: fullWidthTable
   :widths: auto

   Framework / library,Package,Remote flow sources,Taint & value steps,Sinks (total),`CWE‑022` :sub:`Path injection`,`CWE‑036` :sub:`Path traversal`,`CWE‑079` :sub:`Cross-site scripting`,`CWE‑089` :sub:`SQL injection`,`CWE‑090` :sub:`LDAP injection`,`CWE‑094` :sub:`Code injection`,`CWE‑319` :sub:`Cleartext transmission`
   Android,``android.*``,18,,3,,,3,,,,
   `Apache Commons IO <https://commons.apache.org/proper/commons-io/>`_,``org.apache.commons.io``,,22,,,,,,,,
   `Apache Commons Lang <https://commons.apache.org/proper/commons-lang/>`_,``org.apache.commons.lang3``,,370,,,,,,,,
   `Apache Commons Text <https://commons.apache.org/proper/commons-text/>`_,``org.apache.commons.text``,,272,,,,,,,,
   `Apache HttpComponents <https://hc.apache.org/>`_,"``org.apache.hc.core5.*``, ``org.apache.http``",5,133,3,,,3,,,,
   `Google Guava <https://guava.dev/>`_,``com.google.common.*``,,107,6,,6,,,,,
   Java Standard Library,``java.*``,3,313,15,13,,,,,,2
   Java extensions,``javax.*``,22,8,12,,,,,1,1,
   `Spring <https://spring.io/>`_,``org.springframework.*``,29,,14,,,,,14,,
   Others,"``com.esotericsoftware.kryo.io``, ``com.esotericsoftware.kryo5.io``, ``com.fasterxml.jackson.databind``, ``com.unboundid.ldap.sdk``, ``org.apache.commons.codec``, ``org.apache.commons.jexl2``, ``org.apache.commons.jexl3``, ``org.apache.directory.ldap.client.api``, ``org.dom4j``, ``org.xml.sax``, ``org.xmlpull.v1``, ``play.mvc``",7,8,68,,,,,18,,
   Totals,,84,1233,121,13,6,6,,33,1,2

