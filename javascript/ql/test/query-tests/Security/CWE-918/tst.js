import request from 'request';
import requestPromise from 'request-promise';
import superagent from 'superagent';
import http from 'http';
import express from 'express';
import axios from 'axios';
import got from 'got';
import nodeFetch from 'node-fetch';
import url from 'url';
let XhrIo = goog.require('goog.net.XhrIo');
let Uri = goog.require('goog.Uri');

var server = http.createServer(function(req, res) {
    var tainted = url.parse(req.url, true).query.url;

    request("example.com"); // OK

    request(tainted); // NOT OK

    request.get(tainted); // NOT OK

    var options = {};
    options.url = tainted;
    request(options); // NOT OK

    request("http://" + tainted); // NOT OK

    request("http://example.com" + tainted); // NOT OK

    request("http://example.com/" + tainted); // NOT OK

    request("http://example.com/?" + tainted); // OK

    http.get(relativeUrl, {host: tainted}); // NOT OK

    XhrIo.send(new Uri(tainted)); // NOT OK
    new XhrIo().send(new Uri(tainted)); // NOT OK
})
