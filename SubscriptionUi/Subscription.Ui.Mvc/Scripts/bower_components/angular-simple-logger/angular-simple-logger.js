!function s(i, a, c) { function u(n, e) { if (!a[n]) { if (!i[n]) { var r = "function" == typeof require && require; if (!e && r) return r(n, !0); if (l) return l(n, !0); var o = new Error("Cannot find module '" + n + "'"); throw o.code = "MODULE_NOT_FOUND", o } var t = a[n] = { exports: {} }; i[n][0].call(t.exports, function (e) { var r = i[n][1][e]; return u(r || e) }, t, t.exports, s, i, a, c) } return a[n].exports } for (var l = "function" == typeof require && require, e = 0; e < c.length; e++)u(c[e]); return u }({ 1: [function (r, e, n) { angular.module("nemLogging", []), angular.module("nemLogging").provider("nemDebug", function () { var e; return e = r("debug"), this.$get = function () { return e }, this.debug = e, this }); var h = [].slice; angular.module("nemLogging").provider("nemSimpleLogger", ["nemDebugProvider", function (e) { var c, n, i, u, l, f, r, o, t, s, a, g; for (a = e.debug, i = {}, c = {}, t = o = 0, s = (u = ["debug", "info", "warn", "error", "log"]).length; o < s; t = ++o)c[g = u[t]] = t; function d(e) { var r, n, o, t, s, i, a; if (this.$log = e, this.spawn = (s = this.spawn, i = this, function () { return s.apply(i, arguments) }), !this.$log) throw "internalLogger undefined"; if (!l(this.$log)) throw "@$log is invalid"; for (this.doLog = !0, t = {}, a = this, r = function (n) { return t[n] = function () { var r; if (r = 1 <= arguments.length ? h.call(arguments, 0) : [], a.doLog) return f(c[n], a.currentLevel, function () { var e; return (e = a.$log)[n].apply(e, r) }) }, a[n] = t[n] }, n = 0, o = u.length; n < o; n++)r(u[n]); this.LEVELS = c, this.currentLevel = c.error } return f = function (e, r, n) { if (r <= e) return n() }, l = function (e) { var r, n, o; if (r = !1, !e) return r; for (n = 0, o = u.length; n < o && (r = null != e[g = u[n]] && "function" == typeof e[g]); n++); return r }, r = function (e, r) { var n, o, t, s; for (null == i[e] && (i[e] = a(e)), n = i[e], s = {}, o = 0, t = u.length; o < t; o++)s[g = u[o]] = "debug" === g ? n : r[g]; return s }, d.prototype.spawn = function (e) { if ("string" != typeof e) return new d(e || this.$log); if (!l(this.$log)) throw "@$log is invalid"; if (!a) throw "nemDebug is undefined this is probably the light version of this library sep debug logggers is not supported!"; return r(e, this.$log) }, n = d, this.decorator = ["$log", function (e) { var r; return (r = new n(e)).currentLevel = c.debug, r }], this.$get = ["$log", function (e) { return new n(e) }], this }]) }, { debug: 2 }], 2: [function (e, r, s) { function n() { var e; try { e = s.storage.debug } catch (e) { } return e } (s = r.exports = e("./debug")).log = function () { return "object" == typeof console && console.log && Function.prototype.apply.call(console.log, console, arguments) }, s.formatArgs = function () { var e = arguments, r = this.useColors; if (e[0] = (r ? "%c" : "") + this.namespace + (r ? " %c" : " ") + e[0] + (r ? "%c " : " ") + "+" + s.humanize(this.diff), !r) return e; var n = "color: " + this.color; e = [e[0], n, "color: inherit"].concat(Array.prototype.slice.call(e, 1)); var o = 0, t = 0; return e[0].replace(/%[a-z%]/g, function (e) { "%%" !== e && (o++ , "%c" === e && (t = o)) }), e.splice(t, 0, n), e }, s.save = function (e) { try { null == e ? s.storage.removeItem("debug") : s.storage.debug = e } catch (e) { } }, s.load = n, s.useColors = function () { return "WebkitAppearance" in document.documentElement.style || window.console && (console.firebug || console.exception && console.table) || navigator.userAgent.toLowerCase().match(/firefox\/(\d+)/) && 31 <= parseInt(RegExp.$1, 10) }, s.storage = "undefined" != typeof chrome && void 0 !== chrome.storage ? chrome.storage.local : function () { try { return window.localStorage } catch (e) { } }(), s.colors = ["lightseagreen", "forestgreen", "goldenrod", "dodgerblue", "darkorchid", "crimson"], s.formatters.j = function (e) { return JSON.stringify(e) }, s.enable(n()) }, { "./debug": 3 }], 3: [function (e, r, a) { (a = r.exports = function (e) { function r() { } function n() { var t = n, e = +new Date, r = e - (c || e); t.diff = r, t.prev = c, t.curr = e, c = e, null == t.useColors && (t.useColors = a.useColors()), null == t.color && t.useColors && (t.color = a.colors[u++ % a.colors.length]); var s = Array.prototype.slice.call(arguments); s[0] = a.coerce(s[0]), "string" != typeof s[0] && (s = ["%o"].concat(s)); var i = 0; s[0] = s[0].replace(/%([a-z%])/g, function (e, r) { if ("%%" === e) return e; i++; var n = a.formatters[r]; if ("function" == typeof n) { var o = s[i]; e = n.call(t, o), s.splice(i, 1), i-- } return e }), "function" == typeof a.formatArgs && (s = a.formatArgs.apply(t, s)), (n.log || a.log || console.log.bind(console)).apply(t, s) } r.enabled = !1, n.enabled = !0; var o = a.enabled(e) ? n : r; return o.namespace = e, o }).coerce = function (e) { return e instanceof Error ? e.stack || e.message : e }, a.disable = function () { a.enable("") }, a.enable = function (e) { a.save(e); for (var r = (e || "").split(/[\s,]+/), n = r.length, o = 0; o < n; o++)r[o] && ("-" === (e = r[o].replace(/\*/g, ".*?"))[0] ? a.skips.push(new RegExp("^" + e.substr(1) + "$")) : a.names.push(new RegExp("^" + e + "$"))) }, a.enabled = function (e) { var r, n; for (r = 0, n = a.skips.length; r < n; r++)if (a.skips[r].test(e)) return !1; for (r = 0, n = a.names.length; r < n; r++)if (a.names[r].test(e)) return !0; return !1 }, a.humanize = e("ms"), a.names = [], a.skips = [], a.formatters = {}; var c, u = 0 }, { ms: 4 }], 4: [function (e, r, n) { var t = 36e5, s = 864e5; function i(e, r, n) { if (!(e < r)) return e < 1.5 * r ? Math.floor(e / r) + " " + n : Math.ceil(e / r) + " " + n + "s" } r.exports = function (e, r) { return r = r || {}, "string" == typeof e ? function (e) { if (1e4 < (e = "" + e).length) return; var r = /^((?:\d+)?\.?\d+) *(milliseconds?|msecs?|ms|seconds?|secs?|s|minutes?|mins?|m|hours?|hrs?|h|days?|d|years?|yrs?|y)?$/i.exec(e); if (!r) return; var n = parseFloat(r[1]); switch ((r[2] || "ms").toLowerCase()) { case "years": case "year": case "yrs": case "yr": case "y": return 315576e5 * n; case "days": case "day": case "d": return n * s; case "hours": case "hour": case "hrs": case "hr": case "h": return n * t; case "minutes": case "minute": case "mins": case "min": case "m": return 6e4 * n; case "seconds": case "second": case "secs": case "sec": case "s": return 1e3 * n; case "milliseconds": case "millisecond": case "msecs": case "msec": case "ms": return n } }(e) : r.long ? i(o = e, s, "day") || i(o, t, "hour") || i(o, 6e4, "minute") || i(o, 1e3, "second") || o + " ms" : s <= (n = e) ? Math.round(n / s) + "d" : t <= n ? Math.round(n / t) + "h" : 6e4 <= n ? Math.round(n / 6e4) + "m" : 1e3 <= n ? Math.round(n / 1e3) + "s" : n + "ms"; var n, o } }, {}] }, {}, [1]);