/*
 * ====================================================================
 * Licensed to the Apache Software Foundation (ASF) under one
 * or more contributor license agreements.  See the NOTICE file
 * distributed with this work for additional information
 * regarding copyright ownership.  The ASF licenses this file
 * to you under the Apache License, Version 2.0 (the
 * "License"); you may not use this file except in compliance
 * with the License.  You may obtain a copy of the License at
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied.  See the License for the
 * specific language governing permissions and limitations
 * under the License.
 * ====================================================================
 *
 * This software consists of voluntary contributions made by many
 * individuals on behalf of the Apache Software Foundation.  For more
 * information on the Apache Software Foundation, please see
 * <http://www.apache.org/>.
 *
 */

package org.apache.http.entity;

import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.io.UnsupportedEncodingException;
import java.nio.charset.Charset;
import java.nio.charset.UnsupportedCharsetException;


public class StringEntity extends AbstractHttpEntity implements Cloneable {
    public StringEntity(final String string, final ContentType contentType) throws UnsupportedCharsetException {
    }

    public StringEntity(
            final String string, final String mimeType, final String charset) throws UnsupportedEncodingException {
    }

    public StringEntity(final String string, final String charset)
            throws UnsupportedCharsetException {
    }

    public StringEntity(final String string, final Charset charset) {
    }

    public StringEntity(final String string)
            throws UnsupportedEncodingException {
    }

    @Override
    public boolean isRepeatable() {
      return false;
    }

    @Override
    public long getContentLength() {
      return 0;
    }

    @Override
    public InputStream getContent() throws IOException {
      return null;
    }

    @Override
    public void writeTo(final OutputStream outStream) throws IOException {
    }

    @Override
    public boolean isStreaming() {
      return false;
    }

    @Override
    public Object clone() throws CloneNotSupportedException {
      return null;
    }

}
