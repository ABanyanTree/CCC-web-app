﻿/*!
 * FullCalendar v2.9.1
 * Docs & License: http://fullcalendar.io/
 * (c) 2016 Adam Shaw
 */
! function (a) {
    "function" == typeof define && define.amd ? define(["jquery", "moment"], a) : "object" == typeof exports ? module.exports = a(require("jquery"), require("moment")) : a(jQuery, moment)
}(function (a, b) {

    function c(a) {
        return W(a, Ya)
    }

    function d(b) {
        var c, d = {
            views: b.views || {}
        };
        return a.each(b, function (b, e) {
            "views" != b && (a.isPlainObject(e) && !/(time|duration|interval)$/i.test(b) && -1 == a.inArray(b, Ya) ? (c = null, a.each(e, function (a, e) {
                /^(month|week|day|default|basic(Week|Day)?|agenda(Week|Day)?)$/.test(a) ? (d.views[a] || (d.views[a] = {}), d.views[a][b] = e) : (c || (c = {}), c[a] = e)
            }), c && (d[b] = c)) : d[b] = e)
        }), d
    }

    function e(a, b) {
        b.left && a.css({
            "border-left-width": 1,
            "margin-left": b.left - 1
        }), b.right && a.css({
            "border-right-width": 1,
            "margin-right": b.right - 1
        })
    }

    function f(a) {
        a.css({
            "margin-left": "",
            "margin-right": "",
            "border-left-width": "",
            "border-right-width": ""
        })
    }

    function g() {
        a("body").addClass("fc-not-allowed")
    }

    function h() {
        a("body").removeClass("fc-not-allowed")
    }

    function i(b, c, d) {
        var e = Math.floor(c / b.length),
            f = Math.floor(c - e * (b.length - 1)),
            g = [],
            h = [],
            i = [],
            k = 0;
        j(b), b.each(function (c, d) {
            var j = c === b.length - 1 ? f : e,
                l = a(d).outerHeight(!0);
            j > l ? (g.push(d), h.push(l), i.push(a(d).height())) : k += l
        }), d && (c -= k, e = Math.floor(c / g.length), f = Math.floor(c - e * (g.length - 1))), a(g).each(function (b, c) {
            var d = b === g.length - 1 ? f : e,
                j = h[b],
                k = i[b],
                l = d - (j - k);
            d > j && a(c).height(l)
        })
    }

    function j(a) {
        a.height("")
    }

    function k(b) {
        var c = 0;
        return b.find("> span").each(function (b, d) {
            var e = a(d).outerWidth();
            e > c && (c = e)
        }), c++, b.width(c), c
    }

    function l(a, b) {
        var c, d = a.add(b);
        return d.css({
            position: "relative",
            left: -1
        }), c = a.outerHeight() - b.outerHeight(), d.css({
            position: "",
            left: ""
        }), c
    }

    function m(b) {
        var c = b.css("position"),
            d = b.parents().filter(function () {
                var b = a(this);
                return /(auto|scroll)/.test(b.css("overflow") + b.css("overflow-y") + b.css("overflow-x"))
            }).eq(0);
        return "fixed" !== c && d.length ? d : a(b[0].ownerDocument || document)
    }

    function n(a, b) {
        var c = a.offset(),
            d = c.left - (b ? b.left : 0),
            e = c.top - (b ? b.top : 0);
        return {
            left: d,
            right: d + a.outerWidth(),
            top: e,
            bottom: e + a.outerHeight()
        }
    }

    function o(a, b) {
        var c = a.offset(),
            d = q(a),
            e = c.left + t(a, "border-left-width") + d.left - (b ? b.left : 0),
            f = c.top + t(a, "border-top-width") + d.top - (b ? b.top : 0);
        return {
            left: e,
            right: e + a[0].clientWidth,
            top: f,
            bottom: f + a[0].clientHeight
        }
    }

    function p(a, b) {
        var c = a.offset(),
            d = c.left + t(a, "border-left-width") + t(a, "padding-left") - (b ? b.left : 0),
            e = c.top + t(a, "border-top-width") + t(a, "padding-top") - (b ? b.top : 0);
        return {
            left: d,
            right: d + a.width(),
            top: e,
            bottom: e + a.height()
        }
    }

    function q(a) {
        var b = a.innerWidth() - a[0].clientWidth,
            c = {
                left: 0,
                right: 0,
                top: 0,
                bottom: a.innerHeight() - a[0].clientHeight
            };
        return r() && "rtl" == a.css("direction") ? c.left = b : c.right = b, c
    }

    function r() {
        return null === Za && (Za = s()), Za
    }

    function s() {
        var b = a("<div><div/></div>").css({
            position: "absolute",
            top: -1e3,
            left: 0,
            border: 0,
            padding: 0,
            overflow: "scroll",
            direction: "rtl"
        }).appendTo("body"),
            c = b.children(),
            d = c.offset().left > b.offset().left;
        return b.remove(), d
    }

    function t(a, b) {
        return parseFloat(a.css(b)) || 0
    }

    function u(a) {
        return 1 == a.which && !a.ctrlKey
    }

    function v(a) {
        if (void 0 !== a.pageX) return a.pageX;
        var b = a.originalEvent.touches;
        return b ? b[0].pageX : void 0
    }

    function w(a) {
        if (void 0 !== a.pageY) return a.pageY;
        var b = a.originalEvent.touches;
        return b ? b[0].pageY : void 0
    }

    function x(a) {
        return /^touch/.test(a.type)
    }

    function y(a) {
        a.addClass("fc-unselectable").on("selectstart", z)
    }

    function z(a) {
        a.preventDefault()
    }

    function A(a) {
        return window.addEventListener ? (window.addEventListener("scroll", a, !0), !0) : !1
    }

    function B(a) {
        return window.removeEventListener ? (window.removeEventListener("scroll", a, !0), !0) : !1
    }

    function C(a, b) {
        var c = {
            left: Math.max(a.left, b.left),
            right: Math.min(a.right, b.right),
            top: Math.max(a.top, b.top),
            bottom: Math.min(a.bottom, b.bottom)
        };
        return c.left < c.right && c.top < c.bottom ? c : !1
    }

    function D(a, b) {
        return {
            left: Math.min(Math.max(a.left, b.left), b.right),
            top: Math.min(Math.max(a.top, b.top), b.bottom)
        }
    }

    function E(a) {
        return {
            left: (a.left + a.right) / 2,
            top: (a.top + a.bottom) / 2
        }
    }

    function F(a, b) {
        return {
            left: a.left - b.left,
            top: a.top - b.top
        }
    }

    function G(b) {
        var c, d, e = [],
            f = [];
        for ("string" == typeof b ? f = b.split(/\s*,\s*/) : "function" == typeof b ? f = [b] : a.isArray(b) && (f = b), c = 0; c < f.length; c++) d = f[c], "string" == typeof d ? e.push("-" == d.charAt(0) ? {
            field: d.substring(1),
            order: -1
        } : {
            field: d,
            order: 1
        }) : "function" == typeof d && e.push({
            func: d
        });
        return e
    }

    function H(a, b, c) {
        var d, e;
        for (d = 0; d < c.length; d++)
            if (e = I(a, b, c[d])) return e;
        return 0
    }

    function I(a, b, c) {
        return c.func ? c.func(a, b) : J(a[c.field], b[c.field]) * (c.order || 1)
    }

    function J(b, c) {
        return b || c ? null == c ? -1 : null == b ? 1 : "string" === a.type(b) || "string" === a.type(c) ? String(b).localeCompare(String(c)) : b - c : 0
    }

    function K(a, b) {
        var c, d, e, f, g = a.start,
            h = a.end,
            i = b.start,
            j = b.end;
        return h > i && j > g ? (g >= i ? (c = g.clone(), e = !0) : (c = i.clone(), e = !1), j >= h ? (d = h.clone(), f = !0) : (d = j.clone(), f = !1), {
            start: c,
            end: d,
            isStart: e,
            isEnd: f
        }) : void 0
    }

    function L(a, c) {
        return b.duration({
            days: a.clone().stripTime().diff(c.clone().stripTime(), "days"),
            ms: a.time() - c.time()
        })
    }

    function M(a, c) {
        return b.duration({
            days: a.clone().stripTime().diff(c.clone().stripTime(), "days")
        })
    }

    function N(a, c, d) {
        return b.duration(Math.round(a.diff(c, d, !0)), d)
    }

    function O(a, b) {
        var c, d, e;
        for (c = 0; c < _a.length && (d = _a[c], e = P(d, a, b), !(e >= 1 && ha(e))) ; c++);
        return d
    }

    function P(a, c, d) {
        return null != d ? d.diff(c, a, !0) : b.isDuration(c) ? c.as(a) : c.end.diff(c.start, a, !0)
    }

    function Q(a, b, c) {
        var d;
        return T(c) ? (b - a) / c : (d = c.asMonths(), Math.abs(d) >= 1 && ha(d) ? b.diff(a, "months", !0) / d : b.diff(a, "days", !0) / c.asDays())
    }

    function R(a, b) {
        var c, d;
        return T(a) || T(b) ? a / b : (c = a.asMonths(), d = b.asMonths(), Math.abs(c) >= 1 && ha(c) && Math.abs(d) >= 1 && ha(d) ? c / d : a.asDays() / b.asDays())
    }

    function S(a, c) {
        var d;
        return T(a) ? b.duration(a * c) : (d = a.asMonths(), Math.abs(d) >= 1 && ha(d) ? b.duration({
            months: d * c
        }) : b.duration({
            days: a.asDays() * c
        }))
    }

    function T(a) {
        return Boolean(a.hours() || a.minutes() || a.seconds() || a.milliseconds())
    }

    function U(a) {
        return "[object Date]" === Object.prototype.toString.call(a) || a instanceof Date
    }

    function V(a) {
        return /^\d+\:\d+(?:\:\d+\.?(?:\d{3})?)?$/.test(a)
    }

    function W(a, b) {
        var c, d, e, f, g, h, i = {};
        if (b)
            for (c = 0; c < b.length; c++) {
                for (d = b[c], e = [], f = a.length - 1; f >= 0; f--)
                    if (g = a[f][d], "object" == typeof g) e.unshift(g);
                    else if (void 0 !== g) {
                        i[d] = g;
                        break
                    }
                e.length && (i[d] = W(e))
            }
        for (c = a.length - 1; c >= 0; c--) {
            h = a[c];
            for (d in h) d in i || (i[d] = h[d])
        }
        return i
    }

    function X(a) {
        var b = function () { };
        return b.prototype = a, new b
    }

    function Y(a, b) {
        for (var c in a) $(a, c) && (b[c] = a[c])
    }

    function Z(a, b) {
        var c, d, e = ["constructor", "toString", "valueOf"];
        for (c = 0; c < e.length; c++) d = e[c], a[d] !== Object.prototype[d] && (b[d] = a[d])
    }

    function $(a, b) {
        return db.call(a, b)
    }

    function _(b) {
        return /undefined|null|boolean|number|string/.test(a.type(b))
    }

    function aa(b, c, d) {
        if (a.isFunction(b) && (b = [b]), b) {
            var e, f;
            for (e = 0; e < b.length; e++) f = b[e].apply(c, d) || f;
            return f
        }
    }

    function ba() {
        for (var a = 0; a < arguments.length; a++)
            if (void 0 !== arguments[a]) return arguments[a]
    }

    function ca(a) {
        return (a + "").replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;").replace(/'/g, "&#039;").replace(/"/g, "&quot;").replace(/\n/g, "<br />")
    }

    function da(a) {
        return a.replace(/&.*?;/g, "")
    }

    function ea(b) {
        var c = [];
        return a.each(b, function (a, b) {
            null != b && c.push(a + ":" + b)
        }), c.join(";")
    }

    function fa(a) {
        return a.charAt(0).toUpperCase() + a.slice(1)
    }

    function ga(a, b) {
        return a - b
    }

    function ha(a) {
        return a % 1 === 0
    }

    function ia(a, b) {
        var c = a[b];
        return function () {
            return c.apply(a, arguments)
        }
    }

    function ja(a, b, c) {
        var d, e, f, g, h, i = function () {
            var j = +new Date - g;
            b > j ? d = setTimeout(i, b - j) : (d = null, c || (h = a.apply(f, e), f = e = null))
        };
        return function () {
            f = this, e = arguments, g = +new Date;
            var j = c && !d;
            return d || (d = setTimeout(i, b)), j && (h = a.apply(f, e), f = e = null), h
        }
    }

    function ka(b, c) {
        return b && b.then && "resolved" !== b.state() ? c ? b.then(c) : void 0 : a.when(c())
    }

    function la(c, d, e) {
        var f, g, h, i, j = c[0],
            k = 1 == c.length && "string" == typeof j;
        return b.isMoment(j) ? (i = b.apply(null, c), na(j, i)) : U(j) || void 0 === j ? i = b.apply(null, c) : (f = !1, g = !1, k ? eb.test(j) ? (j += "-01", c = [j], f = !0, g = !0) : (h = fb.exec(j)) && (f = !h[5], g = !0) : a.isArray(j) && (g = !0), i = d || f ? b.utc.apply(b, c) : b.apply(null, c), f ? (i._ambigTime = !0, i._ambigZone = !0) : e && (g ? i._ambigZone = !0 : k && (i.utcOffset ? i.utcOffset(j) : i.zone(j)))), i._fullCalendar = !0, i
    }

    function ma(a, c) {
        var d, e, f = !1,
            g = !1,
            h = a.length,
            i = [];
        for (d = 0; h > d; d++) e = a[d], b.isMoment(e) || (e = Wa.moment.parseZone(e)), f = f || e._ambigTime, g = g || e._ambigZone, i.push(e);
        for (d = 0; h > d; d++) e = i[d], c || !f || e._ambigTime ? g && !e._ambigZone && (i[d] = e.clone().stripZone()) : i[d] = e.clone().stripTime();
        return i
    }

    function na(a, b) {
        a._ambigTime ? b._ambigTime = !0 : b._ambigTime && (b._ambigTime = !1), a._ambigZone ? b._ambigZone = !0 : b._ambigZone && (b._ambigZone = !1)
    }

    function oa(a, b) {
        a.year(b[0] || 0).month(b[1] || 0).date(b[2] || 0).hours(b[3] || 0).minutes(b[4] || 0).seconds(b[5] || 0).milliseconds(b[6] || 0)
    }

    function pa(a, b) {
        return hb.format.call(a, b)
    }

    function qa(a, b) {
        return ra(a, wa(b))
    }

    function ra(a, b) {
        var c, d = "";
        for (c = 0; c < b.length; c++) d += sa(a, b[c]);
        return d
    }

    function sa(a, b) {
        var c, d;
        return "string" == typeof b ? b : (c = b.token) ? ib[c] ? ib[c](a) : pa(a, c) : b.maybe && (d = ra(a, b.maybe), d.match(/[1-9]/)) ? d : ""
    }

    function ta(a, b, c, d, e) {
        var f;
        return a = Wa.moment.parseZone(a), b = Wa.moment.parseZone(b), f = (a.localeData || a.lang).call(a), c = f.longDateFormat(c) || c, d = d || " - ", ua(a, b, wa(c), d, e)
    }

    function ua(a, b, c, d, e) {
        var f, g, h, i, j = a.clone().stripZone(),
            k = b.clone().stripZone(),
            l = "",
            m = "",
            n = "",
            o = "",
            p = "";
        for (g = 0; g < c.length && (f = va(a, b, j, k, c[g]), f !== !1) ; g++) l += f;
        for (h = c.length - 1; h > g && (f = va(a, b, j, k, c[h]), f !== !1) ; h--) m = f + m;
        for (i = g; h >= i; i++) n += sa(a, c[i]), o += sa(b, c[i]);
        return (n || o) && (p = e ? o + d + n : n + d + o), l + p + m
    }

    function va(a, b, c, d, e) {
        var f, g;
        return "string" == typeof e ? e : (f = e.token) && (g = jb[f.charAt(0)], g && c.isSame(d, g)) ? pa(a, f) : !1
    }

    function wa(a) {
        return a in kb ? kb[a] : kb[a] = xa(a)
    }

    function xa(a) {
        for (var b, c = [], d = /\[([^\]]*)\]|\(([^\)]*)\)|(LTS|LT|(\w)\4*o?)|([^\w\[\(]+)/g; b = d.exec(a) ;) b[1] ? c.push(b[1]) : b[2] ? c.push({
            maybe: xa(b[2])
        }) : b[3] ? c.push({
            token: b[3]
        }) : b[5] && c.push(b[5]);
        return c
    }

    function ya() { }

    function za(a, b) {
        var c;
        return $(b, "constructor") && (c = b.constructor), "function" != typeof c && (c = b.constructor = function () {
            a.apply(this, arguments)
        }), c.prototype = X(a.prototype), Y(b, c.prototype), Z(b, c.prototype), Y(a, c), c
    }

    function Aa(a, b) {
        Y(b, a.prototype)
    }

    function Ba(a, b) {
        return a || b ? a && b ? a.component === b.component && Ca(a, b) && Ca(b, a) : !1 : !0
    }

    function Ca(a, b) {
        for (var c in a)
            if (!/^(component|left|right|top|bottom)$/.test(c) && a[c] !== b[c]) return !1;
        return !0
    }

    function Da(a) {
        var b = Fa(a);
        return "background" === b || "inverse-background" === b
    }

    function Ea(a) {
        return "inverse-background" === Fa(a)
    }

    function Fa(a) {
        return ba((a.source || {}).rendering, a.rendering)
    }

    function Ga(a) {
        var b, c, d = {};
        for (b = 0; b < a.length; b++) c = a[b], (d[c._id] || (d[c._id] = [])).push(c);
        return d
    }

    function Ha(a, b) {
        return a.start - b.start
    }

    function Ia(c) {
        var d, e, f, g, h = Wa.dataAttrPrefix;
        return h && (h += "-"), d = c.data(h + "event") || null, d && (d = "object" == typeof d ? a.extend({}, d) : {}, e = d.start, null == e && (e = d.time), f = d.duration, g = d.stick, delete d.start, delete d.time, delete d.duration, delete d.stick), null == e && (e = c.data(h + "start")), null == e && (e = c.data(h + "time")), null == f && (f = c.data(h + "duration")), null == g && (g = c.data(h + "stick")), e = null != e ? b.duration(e) : null, f = null != f ? b.duration(f) : null, g = Boolean(g), {
            eventProps: d,
            startTime: e,
            duration: f,
            stick: g
        }
    }

    function Ja(a, b) {
        var c, d;
        for (c = 0; c < b.length; c++)
            if (d = b[c], d.leftCol <= a.rightCol && d.rightCol >= a.leftCol) return !0;
        return !1
    }

    function Ka(a, b) {
        return a.leftCol - b.leftCol
    }

    function La(a) {
        var b, c, d, e = [];
        for (b = 0; b < a.length; b++) {
            for (c = a[b], d = 0; d < e.length && Oa(c, e[d]).length; d++);
            c.level = d, (e[d] || (e[d] = [])).push(c)
        }
        return e
    }

    function Ma(a) {
        var b, c, d, e, f;
        for (b = 0; b < a.length; b++)
            for (c = a[b], d = 0; d < c.length; d++)
                for (e = c[d], e.forwardSegs = [], f = b + 1; f < a.length; f++) Oa(e, a[f], e.forwardSegs)
    }

    function Na(a) {
        var b, c, d = a.forwardSegs,
            e = 0;
        if (void 0 === a.forwardPressure) {
            for (b = 0; b < d.length; b++) c = d[b], Na(c), e = Math.max(e, 1 + c.forwardPressure);
            a.forwardPressure = e
        }
    }

    function Oa(a, b, c) {
        c = c || [];
        for (var d = 0; d < b.length; d++) Pa(a, b[d]) && c.push(b[d]);
        return c
    }

    function Pa(a, b) {
        return a.bottom > b.top && a.top < b.bottom
    }

    function Qa(c, e) {
        function f(a) {
            "_locale" in a ? a._locale = V : a._lang = V
        }

        function g() {
            Y ? k() && (p(), l()) : h()
        }

        function h() {
            c.addClass("fc"), U.bindOption("theme", function (a) {
                Z = a ? "ui" : "fc", c.toggleClass("ui-widget", a), c.toggleClass("fc-unthemed", !a)
            }), U.bindOptions(["isRTL", "lang"], function (a) {
                c.toggleClass("fc-ltr", !a), c.toggleClass("fc-rtl", a)
            }), Y = a("<div class='fc-view-container'/>").prependTo(c), W = U.header = new Ta(U), i(), l(U.options.defaultView), U.options.handleWindowResize && (aa = ja(s, U.options.windowResizeDelay), a(window).resize(aa))
        }

        function i() {
            W.render(), W.el && c.prepend(W.el)
        }

        function j() {
            $ && $.removeElement(), W.removeElement(), Y.remove(), c.removeClass("fc fc-ltr fc-rtl fc-unthemed ui-widget"), aa && a(window).unbind("resize", aa)
        }

        function k() {
            return c.is(":visible")
        }

        function l(b, c) {
            ha++, $ && b && $.type !== b && (N(), m()), !$ && b && ($ = U.view = ga[b] || (ga[b] = U.instantiateView(b)), $.setElement(a("<div class='fc-view fc-" + b + "-view' />").appendTo(Y)), W.activateButton(b)), $ && (ba = $.massageCurrentDate(ba), $.displaying && ba.isWithin($.intervalStart, $.intervalEnd) || k() && ($.display(ba, c), O(), A(), B(), w())), O(), ha--
        }

        function m() {
            W.deactivateButton($.type), $.removeElement(), $ = U.view = null
        }

        function n() {
            ha++, N();
            var a = $.type,
                b = $.queryScroll();
            m(), l(a, b), O(), ha--
        }

        function o(a) {
            return k() ? (a && q(), ha++, $.updateSize(!0), ha--, !0) : void 0
        }

        function p() {
            k() && q()
        }

        function q() {
            var a = U.options.contentHeight,
                b = U.options.height;
            _ = "number" == typeof a ? a : "function" == typeof a ? a() : "number" == typeof b ? b - r() : "function" == typeof b ? b() - r() : "parent" === b ? c.parent().height() - r() : Math.round(Y.width() / Math.max(U.options.aspectRatio, .5))
        }

        function r() {
            return W.el ? W.el.outerHeight(!0) : 0
        }

        function s(a) {
            !ha && a.target === window && $.start && o(!0) && $.trigger("windowResize", fa)
        }

        function t() {
            x()
        }

        function u(a) {
            ea(U.getEventSourcesByMatchArray(a))
        }

        function v() {
            k() && (N(), $.displayEvents(ia), O())
        }

        function w() {
            !U.options.lazyFetching || ca($.start, $.end) ? x() : v()
        }

        function x() {
            da($.start, $.end)
        }

        function y(a) {
            ia = a, v()
        }

        function z() {
            v()
        }

        function A() {
            W.updateTitle($.title)
        }

        function B() {
            var a = U.getNow();
            a.isWithin($.intervalStart, $.intervalEnd) ? W.disableButton("today") : W.enableButton("today")
        }

        function C(a, b) {
            $.select(U.buildSelectSpan.apply(U, arguments))
        }

        function D() {
            $ && $.unselect()
        }

        function E() {
            ba = $.computePrevDate(ba), l()
        }

        function F() {
            ba = $.computeNextDate(ba), l()
        }

        function G() {
            ba.add(-1, "years"), l()
        }

        function H() {
            ba.add(1, "years"), l()
        }

        function I() {
            ba = U.getNow(), l()
        }

        function J(a) {
            ba = U.moment(a).stripZone(), l()
        }

        function K(a) {
            ba.add(b.duration(a)), l()
        }

        function L(a, b) {
            var c;
            b = b || "day", c = U.getViewSpec(b) || U.getUnitViewSpec(b), ba = a.clone(), l(c ? c.type : null)
        }

        function M() {
            return U.applyTimezone(ba)
        }

        function N() {
            Y.css({
                width: "100%",
                height: Y.height(),
                overflow: "hidden"
            })
        }

        function O() {
            Y.css({
                width: "",
                height: "",
                overflow: ""
            })
        }

        function P() {
            return U
        }

        function Q() {
            return $
        }

        function R(a, b) {
            var c;
            if ("string" == typeof a) {
                if (void 0 === b) return U.options[a];
                c = {}, c[a] = b, S(c)
            } else "object" == typeof a && S(a)
        }

        function S(a) {
            var b, c = 0;
            for (b in a) U.dynamicOverrides[b] = a[b];
            U.viewSpecCache = {}, U.populateOptionsHash();
            for (b in a) U.triggerOptionHandlers(b), c++;
            if (1 === c) {
                if ("height" === b || "contentHeight" === b || "aspectRatio" === b) return void o(!0);
                if ("defaultDate" === b) return;
                if ("businessHours" === b) return void ($ && ($.unrenderBusinessHours(), $.renderBusinessHours()));
                if ("timezone" === b) return U.rezoneArrayEventSources(), void t()
            }
            i(), ga = {}, n()
        }

        function T(a, b) {
            var c = Array.prototype.slice.call(arguments, 2);
            return b = b || fa, this.triggerWith(a, b, c), U.options[a] ? U.options[a].apply(b, c) : void 0
        }
        var U = this;
        U.render = g, U.destroy = j, U.refetchEvents = t, U.refetchEventSources = u, U.reportEvents = y, U.reportEventChange = z, U.rerenderEvents = v, U.changeView = l, U.select = C, U.unselect = D, U.prev = E, U.next = F, U.prevYear = G, U.nextYear = H, U.today = I, U.gotoDate = J, U.incrementDate = K, U.zoomTo = L, U.getDate = M, U.getCalendar = P, U.getView = Q, U.option = R, U.trigger = T, U.dynamicOverrides = {}, U.viewSpecCache = {}, U.optionHandlers = {}, U.overrides = d(e || {}), U.populateOptionsHash();
        var V;
        U.bindOptions(["lang", "monthNames", "monthNamesShort", "dayNames", "dayNamesShort", "firstDay", "weekNumberCalculation"], function (a, b, c, d, e, g, h) {
            if (V = X(Sa(a)), b && (V._months = b), c && (V._monthsShort = c), d && (V._weekdays = d), e && (V._weekdaysShort = e), null != g) {
                var i = X(V._week);
                i.dow = g, V._week = i
            }
            "iso" === h && (h = "ISO"), "ISO" !== h && "local" !== h && "function" != typeof h || (V._fullCalendar_weekCalc = h), ba && f(ba)
        }), U.defaultAllDayEventDuration = b.duration(U.options.defaultAllDayEventDuration), U.defaultTimedEventDuration = b.duration(U.options.defaultTimedEventDuration), U.moment = function () {
            var a;
            return "local" === U.options.timezone ? (a = Wa.moment.apply(null, arguments), a.hasTime() && a.local()) : a = "UTC" === U.options.timezone ? Wa.moment.utc.apply(null, arguments) : Wa.moment.parseZone.apply(null, arguments), f(a), a
        }, U.getIsAmbigTimezone = function () {
            return "local" !== U.options.timezone && "UTC" !== U.options.timezone
        }, U.applyTimezone = function (a) {
            if (!a.hasTime()) return a.clone();
            var b, c = U.moment(a.toArray()),
                d = a.time() - c.time();
            return d && (b = c.clone().add(d), a.time() - b.time() === 0 && (c = b)), c
        }, U.getNow = function () {
            var a = U.options.now;
            return "function" == typeof a && (a = a()), U.moment(a).stripZone()
        }, U.getEventEnd = function (a) {
            return a.end ? a.end.clone() : U.getDefaultEventEnd(a.allDay, a.start)
        }, U.getDefaultEventEnd = function (a, b) {
            var c = b.clone();
            return a ? c.stripTime().add(U.defaultAllDayEventDuration) : c.add(U.defaultTimedEventDuration), U.getIsAmbigTimezone() && c.stripZone(), c
        }, U.humanizeDuration = function (a) {
            return (a.locale || a.lang).call(a, U.options.lang).humanize()
        }, Ua.call(U);
        var W, Y, Z, $, _, aa, ba, ca = U.isFetchNeeded,
            da = U.fetchEvents,
            ea = U.fetchEventSources,
            fa = c[0],
            ga = {},
            ha = 0,
            ia = [];
        ba = null != U.options.defaultDate ? U.moment(U.options.defaultDate).stripZone() : U.getNow(), U.getSuggestedViewHeight = function () {
            return void 0 === _ && p(), _
        }, U.isHeightAuto = function () {
            return "auto" === U.options.contentHeight || "auto" === U.options.height
        }, U.freezeContentHeight = N, U.unfreezeContentHeight = O, U.initialize()
    }

    function Ra(b) {
        a.each(Db, function (a, c) {
            null == b[a] && (b[a] = c(b))
        })
    }

    function Sa(a) {
        var c = b.localeData || b.langData;
        return c.call(b, a) || c.call(b, "en")
    }

    function Ta(b) {
        function c() {
            var c = b.options,
                f = c.header;
            n = c.theme ? "ui" : "fc", f ? (m ? m.empty() : m = this.el = a("<div class='fc-toolbar'/>"), m.append(e("left")).append(e("right")).append(e("center")).append('<div class="fc-clear"/>')) : d()
        }

        function d() {
            m && (m.remove(), m = l.el = null)
        }

        function e(c) {
            var d = a('<div class="centerCal fc-' + c + '"/>'),
                e = b.options,
                f = e.header[c];
            return f && a.each(f.split(" "), function (c) {
                var f, g = a(),
                    h = !0;
                a.each(this.split(","), function (c, d) {
                    var f, i, j, k, l, m, p, q, r, s;
                    "title" == d ? (g = g.add(a("<h5>&nbsp;</h5>")), h = !1) : ((f = (e.customButtons || {})[d]) ? (j = function (a) {
                        f.click && f.click.call(s[0], a)
                    }, k = "", l = f.text) : (i = b.getViewSpec(d)) ? (j = function () {
                        b.changeView(d)
                    }, o.push(d), k = i.buttonTextOverride, l = i.buttonTextDefault) : b[d] && (j = function () {
                        b[d]()
                    }, k = (b.overrides.buttonText || {})[d], l = e.buttonText[d]), j && (m = f ? f.themeIcon : e.themeButtonIcons[d], p = f ? f.icon : e.buttonIcons[d], q = k ? ca(k) : m && e.theme ? "<span class='ui-icon ui-icon-" + m + "'></span>" : p && !e.theme ? "<span class='fc-icon fc-icon-" + p + "'></span>" : ca(l), r = ["fc-" + d + "-button", n + "-button", n + "-state-default"], s = a('<button type="button" class="' + r.join(" ") + '">' + q + "</button>").click(function (a) {
                        s.hasClass(n + "-state-disabled") || (j(a), (s.hasClass(n + "-state-active") || s.hasClass(n + "-state-disabled")) && s.removeClass(n + "-state-hover"))
                    }).mousedown(function () {
                        s.not("." + n + "-state-active").not("." + n + "-state-disabled").addClass(n + "-state-down")
                    }).mouseup(function () {
                        s.removeClass(n + "-state-down")
                    }).hover(function () {
                        s.not("." + n + "-state-active").not("." + n + "-state-disabled").addClass(n + "-state-hover")
                    }, function () {
                        s.removeClass(n + "-state-hover").removeClass(n + "-state-down")
                    }), g = g.add(s)))
                }), h && g.first().addClass(n + "-corner-left").end().last().addClass(n + "-corner-right").end(), g.length > 1 ? (f = a("<div/>"), h && f.addClass("fc-button-group"), f.append(g), d.append(f)) : d.append(g)
            }), d
        }

        function f(a) {
            m && m.find("h5").text(a)
        }

        function g(a) {
            m && m.find(".fc-" + a + "-button").addClass(n + "-state-active")
        }

        function h(a) {
            m && m.find(".fc-" + a + "-button").removeClass(n + "-state-active")
        }

        function i(a) {
            m && m.find(".fc-" + a + "-button").prop("disabled", !0).addClass(n + "-state-disabled")
        }

        function j(a) {
            m && m.find(".fc-" + a + "-button").prop("disabled", !1).removeClass(n + "-state-disabled")
        }

        function k() {
            return o
        }
        var l = this;
        l.render = c, l.removeElement = d, l.updateTitle = f, l.activateButton = g, l.deactivateButton = h, l.disableButton = i, l.enableButton = j, l.getViewsWithButtons = k, l.el = null;
        var m, n, o = []
    }

    function Ua() {
        function c(a, b) {
            return !T || T > a || b > U
        }

        function d(a, b) {
            T = a, U = b, e(Y, "reset")
        }

        function e(a, b) {
            var c, d;
            for ("reset" === b ? $ = [] : "add" !== b && ($ = u($, a)), c = 0; c < a.length; c++) d = a[c], "pending" !== d._status && Z++, d._fetchId = (d._fetchId || 0) + 1, d._status = "pending";
            for (c = 0; c < a.length; c++) d = a[c], f(d, d._fetchId)
        }

        function f(b, c) {
            i(b, function (d) {
                var e, f, g, i = a.isArray(b.events);
                if (c === b._fetchId && "rejected" !== b._status) {
                    if (b._status = "resolved", d)
                        for (e = 0; e < d.length; e++) f = d[e], g = i ? f : C(f, b), g && $.push.apply($, G(g));
                    h()
                }
            })
        }

        function g(a) {
            var b = "pending" === a._status;
            a._status = "rejected", b && h()
        }

        function h() {
            Z--, Z || W($)
        }

        function i(b, c) {
            var d, e, f = Wa.sourceFetchers;
            for (d = 0; d < f.length; d++) {
                if (e = f[d].call(S, b, T.clone(), U.clone(), S.options.timezone, c), e === !0) return;
                if ("object" == typeof e) return void i(e, c)
            }
            var g = b.events;
            if (g) a.isFunction(g) ? (S.pushLoading(), g.call(S, T.clone(), U.clone(), S.options.timezone, function (a) {
                c(a), S.popLoading()
            })) : a.isArray(g) ? c(g) : c();
            else {
                var h = b.url;
                if (h) {
                    var j, k = b.success,
                        l = b.error,
                        m = b.complete;
                    j = a.isFunction(b.data) ? b.data() : b.data;
                    var n = a.extend({}, j || {}),
                        o = ba(b.startParam, S.options.startParam),
                        p = ba(b.endParam, S.options.endParam),
                        q = ba(b.timezoneParam, S.options.timezoneParam);
                    o && (n[o] = T.format()), p && (n[p] = U.format()), S.options.timezone && "local" != S.options.timezone && (n[q] = S.options.timezone), S.pushLoading(), a.ajax(a.extend({}, Eb, b, {
                        data: n,
                        success: function (b) {
                            b = b || [];
                            var d = aa(k, this, arguments);
                            a.isArray(d) && (b = d), c(b)
                        },
                        error: function () {
                            aa(l, this, arguments), c()
                        },
                        complete: function () {
                            aa(m, this, arguments), S.popLoading()
                        }
                    }))
                } else c()
            }
        }

        function j(a) {
            var b = k(a);
            b && (Y.push(b), e([b], "add"))
        }

        function k(b) {
            var c, d, e = Wa.sourceNormalizers;
            if (a.isFunction(b) || a.isArray(b) ? c = {
                events: b
            } : "string" == typeof b ? c = {
                url: b
            } : "object" == typeof b && (c = a.extend({}, b)), c) {
                for (c.className ? "string" == typeof c.className && (c.className = c.className.split(/\s+/)) : c.className = [], a.isArray(c.events) && (c.origArray = c.events, c.events = a.map(c.events, function (a) {
                        return C(a, c)
                })), d = 0; d < e.length; d++) e[d].call(S, c);
                return c
            }
        }

        function l(a) {
            n(r(a))
        }

        function m(a) {
            null == a ? n(Y, !0) : n(q(a))
        }

        function n(b, c) {
            var d;
            for (d = 0; d < b.length; d++) g(b[d]);
            c ? (Y = [], $ = []) : (Y = a.grep(Y, function (a) {
                for (d = 0; d < b.length; d++)
                    if (a === b[d]) return !1;
                return !0
            }), $ = u($, b)), W($)
        }

        function o() {
            return Y.slice(1)
        }

        function p(b) {
            return a.grep(Y, function (a) {
                return a.id && a.id === b
            })[0]
        }

        function q(b) {
            b ? a.isArray(b) || (b = [b]) : b = [];
            var c, d = [];
            for (c = 0; c < b.length; c++) d.push.apply(d, r(b[c]));
            return d
        }

        function r(b) {
            var c, d;
            for (c = 0; c < Y.length; c++)
                if (d = Y[c], d === b) return [d];
            return d = p(b), d ? [d] : a.grep(Y, function (a) {
                return s(b, a)
            })
        }

        function s(a, b) {
            return a && b && t(a) == t(b)
        }

        function t(a) {
            return ("object" == typeof a ? a.origArray || a.googleCalendarId || a.url || a.events : null) || a
        }

        function u(b, c) {
            return a.grep(b, function (a) {
                for (var b = 0; b < c.length; b++)
                    if (a.source === c[b]) return !1;
                return !0
            })
        }

        function v(a) {
            a.start = S.moment(a.start), a.end ? a.end = S.moment(a.end) : a.end = null, H(a, w(a)), W($)
        }

        function w(b) {
            var c = {};
            return a.each(b, function (a, b) {
                x(a) && void 0 !== b && _(b) && (c[a] = b)
            }), c
        }

        function x(a) {
            return !/^_|^(id|allDay|start|end)$/.test(a)
        }

        function y(a, b) {
            var c, d, e, f = C(a);
            if (f) {
                for (c = G(f), d = 0; d < c.length; d++) e = c[d], e.source || (b && (X.events.push(e), e.source = X), $.push(e));
                return W($), c
            }
            return []
        }

        function z(b) {
            var c, d;
            for (null == b ? b = function () {
                    return !0
            } : a.isFunction(b) || (c = b + "", b = function (a) {
                    return a._id == c
            }), $ = a.grep($, b, !0), d = 0; d < Y.length; d++) a.isArray(Y[d].events) && (Y[d].events = a.grep(Y[d].events, b, !0));
            W($)
        }

        function A(b) {
            return a.isFunction(b) ? a.grep($, b) : null != b ? (b += "", a.grep($, function (a) {
                return a._id == b
            })) : $
        }

        function B(a) {
            a.start = S.moment(a.start), a.end && (a.end = S.moment(a.end)), Va(a)
        }

        function C(c, d) {
            var e, f, g, h = {};
            if (S.options.eventDataTransform && (c = S.options.eventDataTransform(c)), d && d.eventDataTransform && (c = d.eventDataTransform(c)), a.extend(h, c), d && (h.source = d), h._id = c._id || (void 0 === c.id ? "_fc" + Fb++ : c.id + ""), c.className ? "string" == typeof c.className ? h.className = c.className.split(/\s+/) : h.className = c.className : h.className = [], e = c.start || c.date, f = c.end, V(e) && (e = b.duration(e)), V(f) && (f = b.duration(f)), c.dow || b.isDuration(e) || b.isDuration(f)) h.start = e ? b.duration(e) : null, h.end = f ? b.duration(f) : null, h._recurring = !0;
            else {
                if (e && (e = S.moment(e), !e.isValid())) return !1;
                f && (f = S.moment(f), f.isValid() || (f = null)), g = c.allDay, void 0 === g && (g = ba(d ? d.allDayDefault : void 0, S.options.allDayDefault)), D(e, f, g, h)
            }
            return S.normalizeEvent(h), h
        }

        function D(a, b, c, d) {
            d.start = a, d.end = b, d.allDay = c, E(d), Va(d)
        }

        function E(a) {
            F(a), a.end && !a.end.isAfter(a.start) && (a.end = null), a.end || (S.options.forceEventDuration ? a.end = S.getDefaultEventEnd(a.allDay, a.start) : a.end = null)
        }

        function F(a) {
            null == a.allDay && (a.allDay = !(a.start.hasTime() || a.end && a.end.hasTime())), a.allDay ? (a.start.stripTime(), a.end && a.end.stripTime()) : (a.start.hasTime() || (a.start = S.applyTimezone(a.start.time(0))), a.end && !a.end.hasTime() && (a.end = S.applyTimezone(a.end.time(0))))
        }

        function G(b, c, d) {
            var e, f, g, h, i, j, k, l, m, n = [];
            if (c = c || T, d = d || U, b)
                if (b._recurring) {
                    if (f = b.dow)
                        for (e = {}, g = 0; g < f.length; g++) e[f[g]] = !0;
                    for (h = c.clone().stripTime() ; h.isBefore(d) ;) e && !e[h.day()] || (i = b.start, j = b.end, k = h.clone(), l = null, i && (k = k.time(i)), j && (l = h.clone().time(j)), m = a.extend({}, b), D(k, l, !i && !j, m), n.push(m)), h.add(1, "days")
                } else n.push(b);
            return n
        }

        function H(b, c, d) {
            function e(a, b) {
                return d ? N(a, b, d) : c.allDay ? M(a, b) : L(a, b)
            }
            var f, g, h, i, j, k, l = {};
            return c = c || {}, c.start || (c.start = b.start.clone()), void 0 === c.end && (c.end = b.end ? b.end.clone() : null), null == c.allDay && (c.allDay = b.allDay), E(c), f = {
                start: b._start.clone(),
                end: b._end ? b._end.clone() : S.getDefaultEventEnd(b._allDay, b._start),
                allDay: c.allDay
            }, E(f), g = null !== b._end && null === c.end, h = e(c.start, f.start), c.end ? (i = e(c.end, f.end), j = i.subtract(h)) : j = null, a.each(c, function (a, b) {
                x(a) && void 0 !== b && (l[a] = b)
            }), k = I(A(b._id), g, c.allDay, h, j, l), {
                dateDelta: h,
                durationDelta: j,
                undo: k
            }
        }

        function I(b, c, d, e, f, g) {
            var h = S.getIsAmbigTimezone(),
                i = [];
            return e && !e.valueOf() && (e = null), f && !f.valueOf() && (f = null), a.each(b, function (b, j) {
                var k, l;
                k = {
                    start: j.start.clone(),
                    end: j.end ? j.end.clone() : null,
                    allDay: j.allDay
                }, a.each(g, function (a) {
                    k[a] = j[a]
                }), l = {
                    start: j._start,
                    end: j._end,
                    allDay: d
                }, E(l), c ? l.end = null : f && !l.end && (l.end = S.getDefaultEventEnd(l.allDay, l.start)), e && (l.start.add(e), l.end && l.end.add(e)), f && l.end.add(f), h && !l.allDay && (e || f) && (l.start.stripZone(), l.end && l.end.stripZone()), a.extend(j, g, l), Va(j), i.push(function () {
                    a.extend(j, k), Va(j)
                })
            }),
                function () {
                    for (var a = 0; a < i.length; a++) i[a]()
                }
        }

        function J(a, b) {
            var c = b.source || {},
                d = ba(b.constraint, c.constraint, S.options.eventConstraint),
                e = ba(b.overlap, c.overlap, S.options.eventOverlap);
            return P(a, d, e, b)
        }

        function K(b, c, d) {
            var e, f;
            return d && (e = a.extend({}, d, c), f = G(C(e))[0]), f ? J(b, f) : O(b)
        }

        function O(a) {
            return P(a, S.options.selectConstraint, S.options.selectOverlap)
        }

        function P(a, b, c, d) {
            var e, f, g, h, i, j;
            if (null != b) {
                for (e = Q(b), f = !1, h = 0; h < e.length; h++)
                    if (S.spanContainsSpan(e[h], a)) {
                        f = !0;
                        break
                    }
                if (!f) return !1
            }
            for (g = S.getPeerEvents(a, d), h = 0; h < g.length; h++)
                if (i = g[h], R(i, a)) {
                    if (c === !1) return !1;
                    if ("function" == typeof c && !c(i, d)) return !1;
                    if (d) {
                        if (j = ba(i.overlap, (i.source || {}).overlap), j === !1) return !1;
                        if ("function" == typeof j && !j(d, i)) return !1
                    }
                }
            return !0
        }

        function Q(a) {
            return "businessHours" === a ? S.getCurrentBusinessHourEvents() : "object" == typeof a ? G(C(a)) : A(a)
        }

        function R(a, b) {
            var c = a.start.clone().stripZone(),
                d = S.getEventEnd(a).stripZone();
            return b.start < d && b.end > c
        }
        var S = this;
        S.isFetchNeeded = c, S.fetchEvents = d, S.fetchEventSources = e, S.getEventSources = o, S.getEventSourceById = p, S.getEventSourcesByMatchArray = q, S.getEventSourcesByMatch = r, S.addEventSource = j, S.removeEventSource = l, S.removeEventSources = m, S.updateEvent = v, S.renderEvent = y, S.removeEvents = z, S.clientEvents = A, S.mutateEvent = H, S.normalizeEventDates = E, S.normalizeEventTimes = F;
        var T, U, W = S.reportEvents,
            X = {
                events: []
            },
            Y = [X],
            Z = 0,
            $ = [];
        a.each((S.options.events ? [S.options.events] : []).concat(S.options.eventSources || []), function (a, b) {
            var c = k(b);
            c && Y.push(c)
        }), S.rezoneArrayEventSources = function () {
            var b, c, d;
            for (b = 0; b < Y.length; b++)
                if (c = Y[b].events, a.isArray(c))
                    for (d = 0; d < c.length; d++) B(c[d])
        }, S.buildEventFromInput = C, S.expandEvent = G, S.isEventSpanAllowed = J, S.isExternalSpanAllowed = K, S.isSelectionSpanAllowed = O, S.getEventCache = function () {
            return $
        }
    }

    function Va(a) {
        a._allDay = a.allDay, a._start = a.start.clone(), a._end = a.end ? a.end.clone() : null
    }
    var Wa = a.fullCalendar = {
        version: "2.9.1",
        internalApiVersion: 5
    },
        Xa = Wa.views = {};
    a.fn.fullCalendar = function (b) {
        var c = Array.prototype.slice.call(arguments, 1),
            d = this;
        return this.each(function (e, f) {
            var g, h = a(f),
                i = h.data("fullCalendar");
            "string" == typeof b ? i && a.isFunction(i[b]) && (g = i[b].apply(i, c), e || (d = g), "destroy" === b && h.removeData("fullCalendar")) : i || (i = new zb(h, b), h.data("fullCalendar", i), i.render())
        }), d
    };
    var Ya = ["header", "buttonText", "buttonIcons", "themeButtonIcons"];
    Wa.intersectRanges = K, Wa.applyAll = aa, Wa.debounce = ja, Wa.isInt = ha, Wa.htmlEscape = ca, Wa.cssToStr = ea, Wa.proxy = ia, Wa.capitaliseFirstLetter = fa, Wa.getOuterRect = n, Wa.getClientRect = o, Wa.getContentRect = p, Wa.getScrollbarWidths = q;
    var Za = null;
    Wa.preventDefault = z, Wa.intersectRects = C, Wa.parseFieldSpecs = G, Wa.compareByFieldSpecs = H, Wa.compareByFieldSpec = I, Wa.flexibleCompare = J, Wa.computeIntervalUnit = O, Wa.divideRangeByDuration = Q, Wa.divideDurationByDuration = R, Wa.multiplyDuration = S, Wa.durationHasTime = T;
    var $a = ["sun", "mon", "tue", "wed", "thu", "fri", "sat"],
        _a = ["year", "month", "week", "day", "hour", "minute", "second", "millisecond"];
    Wa.log = function () {
        var a = window.console;
        return a && a.log ? a.log.apply(a, arguments) : void 0
    }, Wa.warn = function () {
        var a = window.console;
        return a && a.warn ? a.warn.apply(a, arguments) : Wa.log.apply(Wa, arguments)
    };
    var ab, bb, cb, db = {}.hasOwnProperty,
        eb = /^\s*\d{4}-\d\d$/,
        fb = /^\s*\d{4}-(?:(\d\d-\d\d)|(W\d\d$)|(W\d\d-\d)|(\d\d\d))((T| )(\d\d(:\d\d(:\d\d(\.\d+)?)?)?)?)?$/,
        gb = b.fn,
        hb = a.extend({}, gb);
    Wa.moment = function () {
        return la(arguments)
    }, Wa.moment.utc = function () {
        var a = la(arguments, !0);
        return a.hasTime() && a.utc(), a
    }, Wa.moment.parseZone = function () {
        return la(arguments, !0, !0)
    }, gb.clone = function () {
        var a = hb.clone.apply(this, arguments);
        return na(this, a), this._fullCalendar && (a._fullCalendar = !0), a
    }, gb.week = gb.weeks = function (a) {
        var b = (this._locale || this._lang)._fullCalendar_weekCalc;
        return null == a && "function" == typeof b ? b(this) : "ISO" === b ? hb.isoWeek.apply(this, arguments) : hb.week.apply(this, arguments)
    }, gb.time = function (a) {
        if (!this._fullCalendar) return hb.time.apply(this, arguments);
        if (null == a) return b.duration({
            hours: this.hours(),
            minutes: this.minutes(),
            seconds: this.seconds(),
            milliseconds: this.milliseconds()
        });
        this._ambigTime = !1, b.isDuration(a) || b.isMoment(a) || (a = b.duration(a));
        var c = 0;
        return b.isDuration(a) && (c = 24 * Math.floor(a.asDays())), this.hours(c + a.hours()).minutes(a.minutes()).seconds(a.seconds()).milliseconds(a.milliseconds())
    }, gb.stripTime = function () {
        var a;
        return this._ambigTime || (a = this.toArray(), this.utc(), bb(this, a.slice(0, 3)), this._ambigTime = !0, this._ambigZone = !0), this
    }, gb.hasTime = function () {
        return !this._ambigTime
    }, gb.stripZone = function () {
        var a, b;
        return this._ambigZone || (a = this.toArray(), b = this._ambigTime, this.utc(), bb(this, a), this._ambigTime = b || !1, this._ambigZone = !0), this
    }, gb.hasZone = function () {
        return !this._ambigZone
    }, gb.local = function () {
        var a = this.toArray(),
            b = this._ambigZone;
        return hb.local.apply(this, arguments), this._ambigTime = !1, this._ambigZone = !1, b && cb(this, a), this
    }, gb.utc = function () {
        return hb.utc.apply(this, arguments), this._ambigTime = !1, this._ambigZone = !1, this
    }, a.each(["zone", "utcOffset"], function (a, b) {
        hb[b] && (gb[b] = function (a) {
            return null != a && (this._ambigTime = !1, this._ambigZone = !1), hb[b].apply(this, arguments)
        })
    }), gb.format = function () {
        return this._fullCalendar && arguments[0] ? qa(this, arguments[0]) : this._ambigTime ? pa(this, "YYYY-MM-DD") : this._ambigZone ? pa(this, "YYYY-MM-DD[T]HH:mm:ss") : hb.format.apply(this, arguments)
    }, gb.toISOString = function () {
        return this._ambigTime ? pa(this, "YYYY-MM-DD") : this._ambigZone ? pa(this, "YYYY-MM-DD[T]HH:mm:ss") : hb.toISOString.apply(this, arguments)
    }, gb.isWithin = function (a, b) {
        var c = ma([this, a, b]);
        return c[0] >= c[1] && c[0] < c[2];
    }, gb.isSame = function (a, b) {
        var c;
        return this._fullCalendar ? b ? (c = ma([this, a], !0), hb.isSame.call(c[0], c[1], b)) : (a = Wa.moment.parseZone(a), hb.isSame.call(this, a) && Boolean(this._ambigTime) === Boolean(a._ambigTime) && Boolean(this._ambigZone) === Boolean(a._ambigZone)) : hb.isSame.apply(this, arguments)
    }, a.each(["isBefore", "isAfter"], function (a, b) {
        gb[b] = function (a, c) {
            var d;
            return this._fullCalendar ? (d = ma([this, a]), hb[b].call(d[0], d[1], c)) : hb[b].apply(this, arguments)
        }
    }), ab = "_d" in b() && "updateOffset" in b, bb = ab ? function (a, c) {
        a._d.setTime(Date.UTC.apply(Date, c)), b.updateOffset(a, !1)
    } : oa, cb = ab ? function (a, c) {
        a._d.setTime(+new Date(c[0] || 0, c[1] || 0, c[2] || 0, c[3] || 0, c[4] || 0, c[5] || 0, c[6] || 0)), b.updateOffset(a, !1)
    } : oa;
    var ib = {
        t: function (a) {
            return pa(a, "a").charAt(0)
        },
        T: function (a) {
            return pa(a, "A").charAt(0)
        }
    };
    Wa.formatRange = ta;
    var jb = {
        Y: "year",
        M: "month",
        D: "day",
        d: "day",
        A: "second",
        a: "second",
        T: "second",
        t: "second",
        H: "second",
        h: "second",
        m: "second",
        s: "second"
    },
        kb = {};
    Wa.Class = ya, ya.extend = function () {
        var a, b, c = arguments.length;
        for (a = 0; c > a; a++) b = arguments[a], c - 1 > a && Aa(this, b);
        return za(this, b || {})
    }, ya.mixin = function (a) {
        Aa(this, a)
    };
    var lb = Wa.EmitterMixin = {
        on: function (b, c) {
            var d = function (a, b) {
                return c.apply(b.context || this, b.args || [])
            };
            return c.guid || (c.guid = a.guid++), d.guid = c.guid, a(this).on(b, d), this
        },
        off: function (b, c) {
            return a(this).off(b, c), this
        },
        trigger: function (b) {
            var c = Array.prototype.slice.call(arguments, 1);
            return a(this).triggerHandler(b, {
                args: c
            }), this
        },
        triggerWith: function (b, c, d) {
            return a(this).triggerHandler(b, {
                context: c,
                args: d
            }), this
        }
    },
        mb = Wa.ListenerMixin = function () {
            var b = 0,
                c = {
                    listenerId: null,
                    listenTo: function (b, c, d) {
                        if ("object" == typeof c)
                            for (var e in c) c.hasOwnProperty(e) && this.listenTo(b, e, c[e]);
                        else "string" == typeof c && b.on(c + "." + this.getListenerNamespace(), a.proxy(d, this))
                    },
                    stopListeningTo: function (a, b) {
                        a.off((b || "") + "." + this.getListenerNamespace())
                    },
                    getListenerNamespace: function () {
                        return null == this.listenerId && (this.listenerId = b++), "_listener" + this.listenerId
                    }
                };
            return c
        }(),
        nb = {
            isIgnoringMouse: !1,
            delayUnignoreMouse: null,
            initMouseIgnoring: function (a) {
                this.delayUnignoreMouse = ja(ia(this, "unignoreMouse"), a || 1e3)
            },
            tempIgnoreMouse: function () {
                this.isIgnoringMouse = !0, this.delayUnignoreMouse()
            },
            unignoreMouse: function () {
                this.isIgnoringMouse = !1
            }
        },
        ob = ya.extend(mb, {
            isHidden: !0,
            options: null,
            el: null,
            margin: 10,
            constructor: function (a) {
                this.options = a || {}
            },
            show: function () {
                this.isHidden && (this.el || this.render(), this.el.show(), this.position(), this.isHidden = !1, this.trigger("show"))
            },
            hide: function () {
                this.isHidden || (this.el.hide(), this.isHidden = !0, this.trigger("hide"))
            },
            render: function () {
                var b = this,
                    c = this.options;
                this.el = a('<div class="fc-popover"/>').addClass(c.className || "").css({
                    top: 0,
                    left: 0
                }).append(c.content).appendTo(c.parentEl), this.el.on("click", ".fc-close", function () {
                    b.hide()
                }), c.autoHide && this.listenTo(a(document), "mousedown", this.documentMousedown)
            },
            documentMousedown: function (b) {
                this.el && !a(b.target).closest(this.el).length && this.hide()
            },
            removeElement: function () {
                this.hide(), this.el && (this.el.remove(), this.el = null), this.stopListeningTo(a(document), "mousedown")
            },
            position: function () {
                var b, c, d, e, f, g = this.options,
                    h = this.el.offsetParent().offset(),
                    i = this.el.outerWidth(),
                    j = this.el.outerHeight(),
                    k = a(window),
                    l = m(this.el);
                e = g.top || 0, f = void 0 !== g.left ? g.left : void 0 !== g.right ? g.right - i : 0, l.is(window) || l.is(document) ? (l = k, b = 0, c = 0) : (d = l.offset(), b = d.top, c = d.left), b += k.scrollTop(), c += k.scrollLeft(), g.viewportConstrain !== !1 && (e = Math.min(e, b + l.outerHeight() - j - this.margin), e = Math.max(e, b + this.margin), f = Math.min(f, c + l.outerWidth() - i - this.margin), f = Math.max(f, c + this.margin)), this.el.css({
                    top: e - h.top,
                    left: f - h.left
                })
            },
            trigger: function (a) {
                this.options[a] && this.options[a].apply(this, Array.prototype.slice.call(arguments, 1))
            }
        }),
        pb = Wa.CoordCache = ya.extend({
            els: null,
            forcedOffsetParentEl: null,
            origin: null,
            boundingRect: null,
            isHorizontal: !1,
            isVertical: !1,
            lefts: null,
            rights: null,
            tops: null,
            bottoms: null,
            constructor: function (b) {
                this.els = a(b.els), this.isHorizontal = b.isHorizontal, this.isVertical = b.isVertical, this.forcedOffsetParentEl = b.offsetParent ? a(b.offsetParent) : null
            },
            build: function () {
                var a = this.forcedOffsetParentEl || this.els.eq(0).offsetParent();
                this.origin = a.offset(), this.boundingRect = this.queryBoundingRect(), this.isHorizontal && this.buildElHorizontals(), this.isVertical && this.buildElVerticals()
            },
            clear: function () {
                this.origin = null, this.boundingRect = null, this.lefts = null, this.rights = null, this.tops = null, this.bottoms = null
            },
            ensureBuilt: function () {
                this.origin || this.build()
            },
            buildElHorizontals: function () {
                var b = [],
                    c = [];
                this.els.each(function (d, e) {
                    var f = a(e),
                        g = f.offset().left,
                        h = f.outerWidth();
                    b.push(g), c.push(g + h)
                }), this.lefts = b, this.rights = c
            },
            buildElVerticals: function () {
                var b = [],
                    c = [];
                this.els.each(function (d, e) {
                    var f = a(e),
                        g = f.offset().top,
                        h = f.outerHeight();
                    b.push(g), c.push(g + h)
                }), this.tops = b, this.bottoms = c
            },
            getHorizontalIndex: function (a) {
                this.ensureBuilt();
                var b, c = this.lefts,
                    d = this.rights,
                    e = c.length;
                for (b = 0; e > b; b++)
                    if (a >= c[b] && a < d[b]) return b
            },
            getVerticalIndex: function (a) {
                this.ensureBuilt();
                var b, c = this.tops,
                    d = this.bottoms,
                    e = c.length;
                for (b = 0; e > b; b++)
                    if (a >= c[b] && a < d[b]) return b
            },
            getLeftOffset: function (a) {
                return this.ensureBuilt(), this.lefts[a]
            },
            getLeftPosition: function (a) {
                return this.ensureBuilt(), this.lefts[a] - this.origin.left
            },
            getRightOffset: function (a) {
                return this.ensureBuilt(), this.rights[a]
            },
            getRightPosition: function (a) {
                return this.ensureBuilt(), this.rights[a] - this.origin.left
            },
            getWidth: function (a) {
                return this.ensureBuilt(), this.rights[a] - this.lefts[a]
            },
            getTopOffset: function (a) {
                return this.ensureBuilt(), this.tops[a]
            },
            getTopPosition: function (a) {
                return this.ensureBuilt(), this.tops[a] - this.origin.top
            },
            getBottomOffset: function (a) {
                return this.ensureBuilt(), this.bottoms[a]
            },
            getBottomPosition: function (a) {
                return this.ensureBuilt(), this.bottoms[a] - this.origin.top
            },
            getHeight: function (a) {
                return this.ensureBuilt(), this.bottoms[a] - this.tops[a]
            },
            queryBoundingRect: function () {
                var a = m(this.els.eq(0));
                return a.is(document) ? void 0 : o(a)
            },
            isPointInBounds: function (a, b) {
                return this.isLeftInBounds(a) && this.isTopInBounds(b)
            },
            isLeftInBounds: function (a) {
                return !this.boundingRect || a >= this.boundingRect.left && a < this.boundingRect.right
            },
            isTopInBounds: function (a) {
                return !this.boundingRect || a >= this.boundingRect.top && a < this.boundingRect.bottom
            }
        }),
        qb = Wa.DragListener = ya.extend(mb, nb, {
            options: null,
            subjectEl: null,
            subjectHref: null,
            originX: null,
            originY: null,
            scrollEl: null,
            isInteracting: !1,
            isDistanceSurpassed: !1,
            isDelayEnded: !1,
            isDragging: !1,
            isTouch: !1,
            delay: null,
            delayTimeoutId: null,
            minDistance: null,
            handleTouchScrollProxy: null,
            constructor: function (a) {
                this.options = a || {}, this.handleTouchScrollProxy = ia(this, "handleTouchScroll"), this.initMouseIgnoring(500)
            },
            startInteraction: function (b, c) {
                var d = x(b);
                if ("mousedown" === b.type) {
                    if (this.isIgnoringMouse) return;
                    if (!u(b)) return;
                    b.preventDefault()
                }
                this.isInteracting || (c = c || {}, this.delay = ba(c.delay, this.options.delay, 0), this.minDistance = ba(c.distance, this.options.distance, 0), this.subjectEl = this.options.subjectEl, this.isInteracting = !0, this.isTouch = d, this.isDelayEnded = !1, this.isDistanceSurpassed = !1, this.originX = v(b), this.originY = w(b), this.scrollEl = m(a(b.target)), this.bindHandlers(), this.initAutoScroll(), this.handleInteractionStart(b), this.startDelay(b), this.minDistance || this.handleDistanceSurpassed(b))
            },
            handleInteractionStart: function (a) {
                this.trigger("interactionStart", a)
            },
            endInteraction: function (a, b) {
                this.isInteracting && (this.endDrag(a), this.delayTimeoutId && (clearTimeout(this.delayTimeoutId), this.delayTimeoutId = null), this.destroyAutoScroll(), this.unbindHandlers(), this.isInteracting = !1, this.handleInteractionEnd(a, b), this.isTouch && this.tempIgnoreMouse())
            },
            handleInteractionEnd: function (a, b) {
                this.trigger("interactionEnd", a, b || !1)
            },
            bindHandlers: function () {
                var b = this,
                    c = 1;
                this.isTouch ? (this.listenTo(a(document), {
                    touchmove: this.handleTouchMove,
                    touchend: this.endInteraction,
                    touchcancel: this.endInteraction,
                    touchstart: function (a) {
                        c ? c-- : b.endInteraction(a, !0)
                    }
                }), !A(this.handleTouchScrollProxy) && this.scrollEl && this.listenTo(this.scrollEl, "scroll", this.handleTouchScroll)) : this.listenTo(a(document), {
                    mousemove: this.handleMouseMove,
                    mouseup: this.endInteraction
                }), this.listenTo(a(document), {
                    selectstart: z,
                    contextmenu: z
                })
            },
            unbindHandlers: function () {
                this.stopListeningTo(a(document)), B(this.handleTouchScrollProxy), this.scrollEl && this.stopListeningTo(this.scrollEl, "scroll")
            },
            startDrag: function (a, b) {
                this.startInteraction(a, b), this.isDragging || (this.isDragging = !0, this.handleDragStart(a))
            },
            handleDragStart: function (a) {
                this.trigger("dragStart", a), this.initHrefHack()
            },
            handleMove: function (a) {
                var b, c = v(a) - this.originX,
                    d = w(a) - this.originY,
                    e = this.minDistance;
                this.isDistanceSurpassed || (b = c * c + d * d, b >= e * e && this.handleDistanceSurpassed(a)), this.isDragging && this.handleDrag(c, d, a)
            },
            handleDrag: function (a, b, c) {
                this.trigger("drag", a, b, c), this.updateAutoScroll(c)
            },
            endDrag: function (a) {
                this.isDragging && (this.isDragging = !1, this.handleDragEnd(a))
            },
            handleDragEnd: function (a) {
                this.trigger("dragEnd", a), this.destroyHrefHack()
            },
            startDelay: function (a) {
                var b = this;
                this.delay ? this.delayTimeoutId = setTimeout(function () {
                    b.handleDelayEnd(a)
                }, this.delay) : this.handleDelayEnd(a)
            },
            handleDelayEnd: function (a) {
                this.isDelayEnded = !0, this.isDistanceSurpassed && this.startDrag(a)
            },
            handleDistanceSurpassed: function (a) {
                this.isDistanceSurpassed = !0, this.isDelayEnded && this.startDrag(a)
            },
            handleTouchMove: function (a) {
                this.isDragging && a.preventDefault(), this.handleMove(a)
            },
            handleMouseMove: function (a) {
                this.handleMove(a)
            },
            handleTouchScroll: function (a) {
                this.isDragging || this.endInteraction(a, !0)
            },
            initHrefHack: function () {
                var a = this.subjectEl;
                (this.subjectHref = a ? a.attr("href") : null) && a.removeAttr("href")
            },
            destroyHrefHack: function () {
                var a = this.subjectEl,
                    b = this.subjectHref;
                setTimeout(function () {
                    b && a.attr("href", b)
                }, 0)
            },
            trigger: function (a) {
                this.options[a] && this.options[a].apply(this, Array.prototype.slice.call(arguments, 1)), this["_" + a] && this["_" + a].apply(this, Array.prototype.slice.call(arguments, 1))
            }
        });
    qb.mixin({
        isAutoScroll: !1,
        scrollBounds: null,
        scrollTopVel: null,
        scrollLeftVel: null,
        scrollIntervalId: null,
        scrollSensitivity: 30,
        scrollSpeed: 200,
        scrollIntervalMs: 50,
        initAutoScroll: function () {
            var a = this.scrollEl;
            this.isAutoScroll = this.options.scroll && a && !a.is(window) && !a.is(document), this.isAutoScroll && this.listenTo(a, "scroll", ja(this.handleDebouncedScroll, 100))
        },
        destroyAutoScroll: function () {
            this.endAutoScroll(), this.isAutoScroll && this.stopListeningTo(this.scrollEl, "scroll")
        },
        computeScrollBounds: function () {
            this.isAutoScroll && (this.scrollBounds = n(this.scrollEl))
        },
        updateAutoScroll: function (a) {
            var b, c, d, e, f = this.scrollSensitivity,
                g = this.scrollBounds,
                h = 0,
                i = 0;
            g && (b = (f - (w(a) - g.top)) / f, c = (f - (g.bottom - w(a))) / f, d = (f - (v(a) - g.left)) / f, e = (f - (g.right - v(a))) / f, b >= 0 && 1 >= b ? h = b * this.scrollSpeed * -1 : c >= 0 && 1 >= c && (h = c * this.scrollSpeed), d >= 0 && 1 >= d ? i = d * this.scrollSpeed * -1 : e >= 0 && 1 >= e && (i = e * this.scrollSpeed)), this.setScrollVel(h, i)
        },
        setScrollVel: function (a, b) {
            this.scrollTopVel = a, this.scrollLeftVel = b, this.constrainScrollVel(), !this.scrollTopVel && !this.scrollLeftVel || this.scrollIntervalId || (this.scrollIntervalId = setInterval(ia(this, "scrollIntervalFunc"), this.scrollIntervalMs))
        },
        constrainScrollVel: function () {
            var a = this.scrollEl;
            this.scrollTopVel < 0 ? a.scrollTop() <= 0 && (this.scrollTopVel = 0) : this.scrollTopVel > 0 && a.scrollTop() + a[0].clientHeight >= a[0].scrollHeight && (this.scrollTopVel = 0), this.scrollLeftVel < 0 ? a.scrollLeft() <= 0 && (this.scrollLeftVel = 0) : this.scrollLeftVel > 0 && a.scrollLeft() + a[0].clientWidth >= a[0].scrollWidth && (this.scrollLeftVel = 0)
        },
        scrollIntervalFunc: function () {
            var a = this.scrollEl,
                b = this.scrollIntervalMs / 1e3;
            this.scrollTopVel && a.scrollTop(a.scrollTop() + this.scrollTopVel * b), this.scrollLeftVel && a.scrollLeft(a.scrollLeft() + this.scrollLeftVel * b), this.constrainScrollVel(), this.scrollTopVel || this.scrollLeftVel || this.endAutoScroll()
        },
        endAutoScroll: function () {
            this.scrollIntervalId && (clearInterval(this.scrollIntervalId), this.scrollIntervalId = null, this.handleScrollEnd())
        },
        handleDebouncedScroll: function () {
            this.scrollIntervalId || this.handleScrollEnd()
        },
        handleScrollEnd: function () { }
    });
    var rb = qb.extend({
        component: null,
        origHit: null,
        hit: null,
        coordAdjust: null,
        constructor: function (a, b) {
            qb.call(this, b), this.component = a
        },
        handleInteractionStart: function (a) {
            var b, c, d, e = this.subjectEl;
            this.computeCoords(), a ? (c = {
                left: v(a),
                top: w(a)
            }, d = c, e && (b = n(e), d = D(d, b)), this.origHit = this.queryHit(d.left, d.top), e && this.options.subjectCenter && (this.origHit && (b = C(this.origHit, b) || b), d = E(b)), this.coordAdjust = F(d, c)) : (this.origHit = null, this.coordAdjust = null), qb.prototype.handleInteractionStart.apply(this, arguments)
        },
        computeCoords: function () {
            this.component.prepareHits(), this.computeScrollBounds()
        },
        handleDragStart: function (a) {
            var b;
            qb.prototype.handleDragStart.apply(this, arguments), b = this.queryHit(v(a), w(a)), b && this.handleHitOver(b)
        },
        handleDrag: function (a, b, c) {
            var d;
            qb.prototype.handleDrag.apply(this, arguments), d = this.queryHit(v(c), w(c)), Ba(d, this.hit) || (this.hit && this.handleHitOut(), d && this.handleHitOver(d))
        },
        handleDragEnd: function () {
            this.handleHitDone(), qb.prototype.handleDragEnd.apply(this, arguments)
        },
        handleHitOver: function (a) {
            var b = Ba(a, this.origHit);
            this.hit = a, this.trigger("hitOver", this.hit, b, this.origHit)
        },
        handleHitOut: function () {
            this.hit && (this.trigger("hitOut", this.hit), this.handleHitDone(), this.hit = null)
        },
        handleHitDone: function () {
            this.hit && this.trigger("hitDone", this.hit)
        },
        handleInteractionEnd: function () {
            qb.prototype.handleInteractionEnd.apply(this, arguments), this.origHit = null, this.hit = null, this.component.releaseHits()
        },
        handleScrollEnd: function () {
            qb.prototype.handleScrollEnd.apply(this, arguments), this.computeCoords()
        },
        queryHit: function (a, b) {
            return this.coordAdjust && (a += this.coordAdjust.left, b += this.coordAdjust.top), this.component.queryHit(a, b)
        }
    }),
        sb = ya.extend(mb, {
            options: null,
            sourceEl: null,
            el: null,
            parentEl: null,
            top0: null,
            left0: null,
            y0: null,
            x0: null,
            topDelta: null,
            leftDelta: null,
            isFollowing: !1,
            isHidden: !1,
            isAnimating: !1,
            constructor: function (b, c) {
                this.options = c = c || {}, this.sourceEl = b, this.parentEl = c.parentEl ? a(c.parentEl) : b.parent()
            },
            start: function (b) {
                this.isFollowing || (this.isFollowing = !0, this.y0 = w(b), this.x0 = v(b), this.topDelta = 0, this.leftDelta = 0, this.isHidden || this.updatePosition(), x(b) ? this.listenTo(a(document), "touchmove", this.handleMove) : this.listenTo(a(document), "mousemove", this.handleMove))
            },
            stop: function (b, c) {
                function d() {
                    e.isAnimating = !1, e.removeElement(), e.top0 = e.left0 = null, c && c()
                }
                var e = this,
                    f = this.options.revertDuration;
                this.isFollowing && !this.isAnimating && (this.isFollowing = !1, this.stopListeningTo(a(document)), b && f && !this.isHidden ? (this.isAnimating = !0, this.el.animate({
                    top: this.top0,
                    left: this.left0
                }, {
                    duration: f,
                    complete: d
                })) : d())
            },
            getEl: function () {
                var a = this.el;
                return a || (this.sourceEl.width(), a = this.el = this.sourceEl.clone().addClass(this.options.additionalClass || "").css({
                    position: "absolute",
                    visibility: "",
                    display: this.isHidden ? "none" : "",
                    margin: 0,
                    right: "auto",
                    bottom: "auto",
                    width: this.sourceEl.width(),
                    height: this.sourceEl.height(),
                    opacity: this.options.opacity || "",
                    zIndex: this.options.zIndex
                }), a.addClass("fc-unselectable"), a.appendTo(this.parentEl)), a
            },
            removeElement: function () {
                this.el && (this.el.remove(), this.el = null)
            },
            updatePosition: function () {
                var a, b;
                this.getEl(), null === this.top0 && (this.sourceEl.width(), a = this.sourceEl.offset(), b = this.el.offsetParent().offset(), this.top0 = a.top - b.top, this.left0 = a.left - b.left), this.el.css({
                    top: this.top0 + this.topDelta,
                    left: this.left0 + this.leftDelta
                })
            },
            handleMove: function (a) {
                this.topDelta = w(a) - this.y0, this.leftDelta = v(a) - this.x0, this.isHidden || this.updatePosition()
            },
            hide: function () {
                this.isHidden || (this.isHidden = !0, this.el && this.el.hide())
            },
            show: function () {
                this.isHidden && (this.isHidden = !1, this.updatePosition(), this.getEl().show())
            }
        }),
        tb = Wa.Grid = ya.extend(mb, nb, {
            view: null,
            isRTL: null,
            start: null,
            end: null,
            el: null,
            elsByFill: null,
            eventTimeFormat: null,
            displayEventTime: null,
            displayEventEnd: null,
            minResizeDuration: null,
            largeUnit: null,
            dayDragListener: null,
            segDragListener: null,
            segResizeListener: null,
            externalDragListener: null,
            constructor: function (a) {
                this.view = a, this.isRTL = a.opt("isRTL"), this.elsByFill = {}, this.dayDragListener = this.buildDayDragListener(), this.initMouseIgnoring()
            },
            computeEventTimeFormat: function () {
                return this.view.opt("smallTimeFormat")
            },
            computeDisplayEventTime: function () {
                return !0
            },
            computeDisplayEventEnd: function () {
                return !0
            },
            setRange: function (a) {
                this.start = a.start.clone(), this.end = a.end.clone(), this.rangeUpdated(), this.processRangeOptions()
            },
            rangeUpdated: function () { },
            processRangeOptions: function () {
                var a, b, c = this.view;
                this.eventTimeFormat = c.opt("eventTimeFormat") || c.opt("timeFormat") || this.computeEventTimeFormat(), a = c.opt("displayEventTime"), null == a && (a = this.computeDisplayEventTime()), b = c.opt("displayEventEnd"), null == b && (b = this.computeDisplayEventEnd()), this.displayEventTime = a, this.displayEventEnd = b
            },
            spanToSegs: function (a) { },
            diffDates: function (a, b) {
                return this.largeUnit ? N(a, b, this.largeUnit) : L(a, b)
            },
            prepareHits: function () { },
            releaseHits: function () { },
            queryHit: function (a, b) { },
            getHitSpan: function (a) { },
            getHitEl: function (a) { },
            setElement: function (a) {
                this.el = a, y(a), this.bindDayHandler("touchstart", this.dayTouchStart), this.bindDayHandler("mousedown", this.dayMousedown), this.bindSegHandlers(), this.bindGlobalHandlers()
            },
            bindDayHandler: function (b, c) {
                var d = this;
                this.el.on(b, function (b) {
                    return a(b.target).is(".fc-event-container *, .fc-more") ? void 0 : c.call(d, b)
                })
            },
            removeElement: function () {
                this.unbindGlobalHandlers(), this.clearDragListeners(), this.el.remove()
            },
            renderSkeleton: function () { },
            renderDates: function () { },
            unrenderDates: function () { },
            bindGlobalHandlers: function () {
                this.listenTo(a(document), {
                    dragstart: this.externalDragStart,
                    sortstart: this.externalDragStart
                })
            },
            unbindGlobalHandlers: function () {
                this.stopListeningTo(a(document))
            },
            dayMousedown: function (a) {
                this.isIgnoringMouse || this.dayDragListener.startInteraction(a, {})
            },
            dayTouchStart: function (a) {
                var b = this.view;
                (b.isSelected || b.selectedEvent) && this.tempIgnoreMouse(), this.dayDragListener.startInteraction(a, {
                    delay: this.view.opt("longPressDelay")
                })
            },
            buildDayDragListener: function () {
                var a, b, c = this,
                    d = this.view,
                    e = d.opt("selectable"),
                    f = new rb(this, {
                        scroll: d.opt("dragScroll"),
                        interactionStart: function () {
                            a = f.origHit, b = null
                        },
                        dragStart: function () {
                            d.unselect()
                        },
                        hitOver: function (d, f, h) {
                            h && (f || (a = null), e && (b = c.computeSelection(c.getHitSpan(h), c.getHitSpan(d)), b ? c.renderSelection(b) : b === !1 && g()))
                        },
                        hitOut: function () {
                            a = null, b = null, c.unrenderSelection()
                        },
                        hitDone: function () {
                            h()
                        },
                        interactionEnd: function (e, f) {
                            f || (a && !c.isIgnoringMouse && d.triggerDayClick(c.getHitSpan(a), c.getHitEl(a), e), b && d.reportSelection(b, e))
                        }
                    });
                return f
            },
            clearDragListeners: function () {
                this.dayDragListener.endInteraction(), this.segDragListener && this.segDragListener.endInteraction(), this.segResizeListener && this.segResizeListener.endInteraction(), this.externalDragListener && this.externalDragListener.endInteraction()
            },
            renderEventLocationHelper: function (a, b) {
                var c = this.fabricateHelperEvent(a, b);
                return this.renderHelper(c, b)
            },
            fabricateHelperEvent: function (a, b) {
                var c = b ? X(b.event) : {};
                return c.start = a.start.clone(), c.end = a.end ? a.end.clone() : null, c.allDay = null, this.view.calendar.normalizeEventDates(c), c.className = (c.className || []).concat("fc-helper"), b || (c.editable = !1), c
            },
            renderHelper: function (a, b) { },
            unrenderHelper: function () { },
            renderSelection: function (a) {
                this.renderHighlight(a)
            },
            unrenderSelection: function () {
                this.unrenderHighlight()
            },
            computeSelection: function (a, b) {
                var c = this.computeSelectionSpan(a, b);
                return c && !this.view.calendar.isSelectionSpanAllowed(c) ? !1 : c
            },
            computeSelectionSpan: function (a, b) {
                var c = [a.start, a.end, b.start, b.end];
                return c.sort(ga), {
                    start: c[0].clone(),
                    end: c[3].clone()
                }
            },
            renderHighlight: function (a) {
                this.renderFill("highlight", this.spanToSegs(a))
            },
            unrenderHighlight: function () {
                this.unrenderFill("highlight")
            },
            highlightSegClasses: function () {
                return ["fc-highlight"]
            },
            renderBusinessHours: function () { },
            unrenderBusinessHours: function () { },
            getNowIndicatorUnit: function () { },
            renderNowIndicator: function (a) { },
            unrenderNowIndicator: function () { },
            renderFill: function (a, b) { },
            unrenderFill: function (a) {
                var b = this.elsByFill[a];
                b && (b.remove(), delete this.elsByFill[a])
            },
            renderFillSegEls: function (b, c) {
                var d, e = this,
                    f = this[b + "SegEl"],
                    g = "",
                    h = [];
                if (c.length) {
                    for (d = 0; d < c.length; d++) g += this.fillSegHtml(b, c[d]);
                    a(g).each(function (b, d) {
                        var g = c[b],
                            i = a(d);
                        f && (i = f.call(e, g, i)), i && (i = a(i), i.is(e.fillSegTag) && (g.el = i, h.push(g)))
                    })
                }
                return h
            },
            fillSegTag: "div",
            fillSegHtml: function (a, b) {
                var c = this[a + "SegClasses"],
                    d = this[a + "SegCss"],
                    e = c ? c.call(this, b) : [],
                    f = ea(d ? d.call(this, b) : {});
                return "<" + this.fillSegTag + (e.length ? ' class="' + e.join(" ") + '"' : "") + (f ? ' style="' + f + '"' : "") + " />"
            },
            getDayClasses: function (a) {
                var b = this.view,
                    c = b.calendar.getNow(),
                    d = ["fc-" + $a[a.day()]];
                return 1 == b.intervalDuration.as("months") && a.month() != b.intervalStart.month() && d.push("fc-other-month"), a.isSame(c, "day") ? d.push("fc-today", b.highlightStateClass) : c > a ? d.push("fc-past") : d.push("fc-future"), d
            }
        });
    tb.mixin({
        mousedOverSeg: null,
        isDraggingSeg: !1,
        isResizingSeg: !1,
        isDraggingExternal: !1,
        segs: null,
        renderEvents: function (a) {
            var b, c = [],
                d = [];
            for (b = 0; b < a.length; b++) (Da(a[b]) ? c : d).push(a[b]);
            this.segs = [].concat(this.renderBgEvents(c), this.renderFgEvents(d))
        },
        renderBgEvents: function (a) {
            var b = this.eventsToSegs(a);
            return this.renderBgSegs(b) || b
        },
        renderFgEvents: function (a) {
            var b = this.eventsToSegs(a);
            return this.renderFgSegs(b) || b
        },
        unrenderEvents: function () {
            this.handleSegMouseout(), this.clearDragListeners(), this.unrenderFgSegs(), this.unrenderBgSegs(), this.segs = null
        },
        getEventSegs: function () {
            return this.segs || []
        },
        renderFgSegs: function (a) { },
        unrenderFgSegs: function () { },
        renderFgSegEls: function (b, c) {
            var d, e = this.view,
                f = "",
                g = [];
            if (b.length) {
                for (d = 0; d < b.length; d++) f += this.fgSegHtml(b[d], c);
                a(f).each(function (c, d) {
                    var f = b[c],
                        h = e.resolveEventEl(f.event, a(d));
                    h && (h.data("fc-seg", f), f.el = h, g.push(f))
                })
            }
            return g
        },
        fgSegHtml: function (a, b) { },
        renderBgSegs: function (a) {
            return this.renderFill("bgEvent", a)
        },
        unrenderBgSegs: function () {
            this.unrenderFill("bgEvent")
        },
        bgEventSegEl: function (a, b) {
            return this.view.resolveEventEl(a.event, b)
        },
        bgEventSegClasses: function (a) {
            var b = a.event,
                c = b.source || {};
            return ["fc-bgevent"].concat(b.className, c.className || [])
        },
        bgEventSegCss: function (a) {
            return {
                "background-color": this.getSegSkinCss(a)["background-color"]
            }
        },
        businessHoursSegClasses: function (a) {
            return ["fc-nonbusiness", "fc-bgevent"]
        },
        buildBusinessHourSegs: function (b) {
            var c = this.view.calendar.getCurrentBusinessHourEvents(b);
            return !c.length && this.view.calendar.options.businessHours && (c = [a.extend({}, Gb, {
                start: this.view.end,
                end: this.view.end,
                dow: null
            })]), this.eventsToSegs(c)
        },
        bindSegHandlers: function () {
            this.bindSegHandlersToEl(this.el)
        },
        bindSegHandlersToEl: function (a) {
            this.bindSegHandlerToEl(a, "touchstart", this.handleSegTouchStart), this.bindSegHandlerToEl(a, "touchend", this.handleSegTouchEnd), this.bindSegHandlerToEl(a, "mouseenter", this.handleSegMouseover), this.bindSegHandlerToEl(a, "mouseleave", this.handleSegMouseout), this.bindSegHandlerToEl(a, "mousedown", this.handleSegMousedown), this.bindSegHandlerToEl(a, "click", this.handleSegClick)
        },
        bindSegHandlerToEl: function (b, c, d) {
            var e = this;
            b.on(c, ".fc-event-container > *", function (b) {
                var c = a(this).data("fc-seg");
                return !c || e.isDraggingSeg || e.isResizingSeg ? void 0 : d.call(e, c, b)
            })
        },
        handleSegClick: function (a, b) {
            return this.view.trigger("eventClick", a.el[0], a.event, b)
        },
        handleSegMouseover: function (a, b) {
            this.isIgnoringMouse || this.mousedOverSeg || (this.mousedOverSeg = a, a.el.addClass("fc-allow-mouse-resize"), this.view.trigger("eventMouseover", a.el[0], a.event, b))
        },
        handleSegMouseout: function (a, b) {
            b = b || {}, this.mousedOverSeg && (a = a || this.mousedOverSeg, this.mousedOverSeg = null, a.el.removeClass("fc-allow-mouse-resize"), this.view.trigger("eventMouseout", a.el[0], a.event, b))
        },
        handleSegMousedown: function (a, b) {
            var c = this.startSegResize(a, b, {
                distance: 5
            });
            !c && this.view.isEventDraggable(a.event) && this.buildSegDragListener(a).startInteraction(b, {
                distance: 5
            })
        },
        handleSegTouchStart: function (a, b) {
            var c, d = this.view,
                e = a.event,
                f = d.isEventSelected(e),
                g = d.isEventDraggable(e),
                h = d.isEventResizable(e),
                i = !1;
            f && h && (i = this.startSegResize(a, b)), i || !g && !h || (c = g ? this.buildSegDragListener(a) : this.buildSegSelectListener(a), c.startInteraction(b, {
                delay: f ? 0 : this.view.opt("longPressDelay")
            })), this.tempIgnoreMouse()
        },
        handleSegTouchEnd: function (a, b) {
            this.tempIgnoreMouse()
        },
        startSegResize: function (b, c, d) {
            return a(c.target).is(".fc-resizer") ? (this.buildSegResizeListener(b, a(c.target).is(".fc-start-resizer")).startInteraction(c, d), !0) : !1
        },
        buildSegDragListener: function (a) {
            var b, c, d, e = this,
                f = this.view,
                i = f.calendar,
                j = a.el,
                k = a.event;
            if (this.segDragListener) return this.segDragListener;
            var l = this.segDragListener = new rb(f, {
                scroll: f.opt("dragScroll"),
                subjectEl: j,
                subjectCenter: !0,
                interactionStart: function (d) {
                    a.component = e, b = !1, c = new sb(a.el, {
                        additionalClass: "fc-dragging",
                        parentEl: f.el,
                        opacity: l.isTouch ? null : f.opt("dragOpacity"),
                        revertDuration: f.opt("dragRevertDuration"),
                        zIndex: 2
                    }), c.hide(), c.start(d)
                },
                dragStart: function (c) {
                    l.isTouch && !f.isEventSelected(k) && f.selectEvent(k), b = !0, e.handleSegMouseout(a, c), e.segDragStart(a, c), f.hideEvent(k)
                },
                hitOver: function (b, h, j) {
                    var m;
                    a.hit && (j = a.hit), d = e.computeEventDrop(j.component.getHitSpan(j), b.component.getHitSpan(b), k), d && !i.isEventSpanAllowed(e.eventToSpan(d), k) && (g(), d = null), d && (m = f.renderDrag(d, a)) ? (m.addClass("fc-dragging"), l.isTouch || e.applyDragOpacity(m), c.hide()) : c.show(), h && (d = null)
                },
                hitOut: function () {
                    f.unrenderDrag(), c.show(), d = null
                },
                hitDone: function () {
                    h()
                },
                interactionEnd: function (g) {
                    delete a.component, c.stop(!d, function () {
                        b && (f.unrenderDrag(), f.showEvent(k), e.segDragStop(a, g)), d && f.reportEventDrop(k, d, this.largeUnit, j, g)
                    }), e.segDragListener = null
                }
            });
            return l
        },
        buildSegSelectListener: function (a) {
            var b = this,
                c = this.view,
                d = a.event;
            if (this.segDragListener) return this.segDragListener;
            var e = this.segDragListener = new qb({
                dragStart: function (a) {
                    e.isTouch && !c.isEventSelected(d) && c.selectEvent(d)
                },
                interactionEnd: function (a) {
                    b.segDragListener = null
                }
            });
            return e
        },
        segDragStart: function (a, b) {
            this.isDraggingSeg = !0, this.view.trigger("eventDragStart", a.el[0], a.event, b, {})
        },
        segDragStop: function (a, b) {
            this.isDraggingSeg = !1, this.view.trigger("eventDragStop", a.el[0], a.event, b, {})
        },
        computeEventDrop: function (a, b, c) {
            var d, e, f = this.view.calendar,
                g = a.start,
                h = b.start;
            return g.hasTime() === h.hasTime() ? (d = this.diffDates(h, g), c.allDay && T(d) ? (e = {
                start: c.start.clone(),
                end: f.getEventEnd(c),
                allDay: !1
            }, f.normalizeEventTimes(e)) : e = {
                start: c.start.clone(),
                end: c.end ? c.end.clone() : null,
                allDay: c.allDay
            }, e.start.add(d), e.end && e.end.add(d)) : e = {
                start: h.clone(),
                end: null,
                allDay: !h.hasTime()
            }, e
        },
        applyDragOpacity: function (a) {
            var b = this.view.opt("dragOpacity");
            null != b && a.each(function (a, c) {
                c.style.opacity = b
            })
        },
        externalDragStart: function (b, c) {
            var d, e, f = this.view;
            f.opt("droppable") && (d = a((c ? c.item : null) || b.target), e = f.opt("dropAccept"), (a.isFunction(e) ? e.call(d[0], d) : d.is(e)) && (this.isDraggingExternal || this.listenToExternalDrag(d, b, c)))
        },
        listenToExternalDrag: function (a, b, c) {
            var d, e = this,
                f = this.view.calendar,
                i = Ia(a),
                j = e.externalDragListener = new rb(this, {
                    interactionStart: function () {
                        e.isDraggingExternal = !0
                    },
                    hitOver: function (a) {
                        d = e.computeExternalDrop(a.component.getHitSpan(a), i), d && !f.isExternalSpanAllowed(e.eventToSpan(d), d, i.eventProps) && (g(), d = null), d && e.renderDrag(d)
                    },
                    hitOut: function () {
                        d = null
                    },
                    hitDone: function () {
                        h(), e.unrenderDrag()
                    },
                    interactionEnd: function (b) {
                        d && e.view.reportExternalDrop(i, d, a, b, c), e.isDraggingExternal = !1, e.externalDragListener = null
                    }
                });
            j.startDrag(b)
        },
        computeExternalDrop: function (a, b) {
            var c = this.view.calendar,
                d = {
                    start: c.applyTimezone(a.start),
                    end: null
                };
            return b.startTime && !d.start.hasTime() && d.start.time(b.startTime), b.duration && (d.end = d.start.clone().add(b.duration)), d
        },
        renderDrag: function (a, b) { },
        unrenderDrag: function () { },
        buildSegResizeListener: function (a, b) {
            var c, d, e = this,
                f = this.view,
                i = f.calendar,
                j = a.el,
                k = a.event,
                l = i.getEventEnd(k),
                m = this.segResizeListener = new rb(this, {
                    scroll: f.opt("dragScroll"),
                    subjectEl: j,
                    interactionStart: function () {
                        c = !1
                    },
                    dragStart: function (b) {
                        c = !0, e.handleSegMouseout(a, b), e.segResizeStart(a, b)
                    },
                    hitOver: function (c, h, j) {
                        var m = e.getHitSpan(j),
                            n = e.getHitSpan(c);
                        d = b ? e.computeEventStartResize(m, n, k) : e.computeEventEndResize(m, n, k), d && (i.isEventSpanAllowed(e.eventToSpan(d), k) ? d.start.isSame(k.start) && d.end.isSame(l) && (d = null) : (g(), d = null)), d && (f.hideEvent(k), e.renderEventResize(d, a))
                    },
                    hitOut: function () {
                        d = null
                    },
                    hitDone: function () {
                        e.unrenderEventResize(), f.showEvent(k), h()
                    },
                    interactionEnd: function (b) {
                        c && e.segResizeStop(a, b), d && f.reportEventResize(k, d, this.largeUnit, j, b), e.segResizeListener = null
                    }
                });
            return m
        },
        segResizeStart: function (a, b) {
            this.isResizingSeg = !0, this.view.trigger("eventResizeStart", a.el[0], a.event, b, {})
        },
        segResizeStop: function (a, b) {
            this.isResizingSeg = !1, this.view.trigger("eventResizeStop", a.el[0], a.event, b, {})
        },
        computeEventStartResize: function (a, b, c) {
            return this.computeEventResize("start", a, b, c)
        },
        computeEventEndResize: function (a, b, c) {
            return this.computeEventResize("end", a, b, c)
        },
        computeEventResize: function (a, b, c, d) {
            var e, f, g = this.view.calendar,
                h = this.diffDates(c[a], b[a]);
            return e = {
                start: d.start.clone(),
                end: g.getEventEnd(d),
                allDay: d.allDay
            }, e.allDay && T(h) && (e.allDay = !1, g.normalizeEventTimes(e)), e[a].add(h), e.start.isBefore(e.end) || (f = this.minResizeDuration || (d.allDay ? g.defaultAllDayEventDuration : g.defaultTimedEventDuration), "start" == a ? e.start = e.end.clone().subtract(f) : e.end = e.start.clone().add(f)), e
        },
        renderEventResize: function (a, b) { },
        unrenderEventResize: function () { },
        getEventTimeText: function (a, b, c) {
            return null == b && (b = this.eventTimeFormat), null == c && (c = this.displayEventEnd), this.displayEventTime && a.start.hasTime() ? c && a.end ? this.view.formatRange(a, b) : a.start.format(b) : ""
        },
        getSegClasses: function (a, b, c) {
            var d = this.view,
                e = a.event,
                f = ["fc-event", a.isStart ? "fc-start" : "fc-not-start", a.isEnd ? "fc-end" : "fc-not-end"].concat(e.className, e.source ? e.source.className : []);
            return b && f.push("fc-draggable"), c && f.push("fc-resizable"), d.isEventSelected(e) && f.push("fc-selected"), f
        },
        getSegSkinCss: function (a) {
            var b = a.event,
                c = this.view,
                d = b.source || {},
                e = b.color,
                f = d.color,
                g = c.opt("eventColor");
            return {
                "background-color": b.backgroundColor || e || d.backgroundColor || f || c.opt("eventBackgroundColor") || g,
                "border-color": b.borderColor || e || d.borderColor || f || c.opt("eventBorderColor") || g,
                color: b.textColor || d.textColor || c.opt("eventTextColor")
            }
        },
        eventToSegs: function (a) {
            return this.eventsToSegs([a])
        },
        eventToSpan: function (a) {
            return this.eventToSpans(a)[0]
        },
        eventToSpans: function (a) {
            var b = this.eventToRange(a);
            return this.eventRangeToSpans(b, a)
        },
        eventsToSegs: function (b, c) {
            var d = this,
                e = Ga(b),
                f = [];
            return a.each(e, function (a, b) {
                var e, g = [];
                for (e = 0; e < b.length; e++) g.push(d.eventToRange(b[e]));
                if (Ea(b[0]))
                    for (g = d.invertRanges(g), e = 0; e < g.length; e++) f.push.apply(f, d.eventRangeToSegs(g[e], b[0], c));
                else
                    for (e = 0; e < g.length; e++) f.push.apply(f, d.eventRangeToSegs(g[e], b[e], c))
            }), f
        },
        eventToRange: function (a) {
            return {
                start: a.start.clone().stripZone(),
                end: (a.end ? a.end.clone() : this.view.calendar.getDefaultEventEnd(null != a.allDay ? a.allDay : !a.start.hasTime(), a.start)).stripZone()
            }
        },
        eventRangeToSegs: function (a, b, c) {
            var d, e = this.eventRangeToSpans(a, b),
                f = [];
            for (d = 0; d < e.length; d++) f.push.apply(f, this.eventSpanToSegs(e[d], b, c));
            return f
        },
        eventRangeToSpans: function (b, c) {
            return [a.extend({}, b)]
        },
        eventSpanToSegs: function (a, b, c) {
            var d, e, f = c ? c(a) : this.spanToSegs(a);
            for (d = 0; d < f.length; d++) e = f[d], e.event = b, e.eventStartMS = +a.start, e.eventDurationMS = a.end - a.start;
            return f
        },
        invertRanges: function (a) {
            var b, c, d = this.view,
                e = d.start.clone(),
                f = d.end.clone(),
                g = [],
                h = e;
            for (a.sort(Ha), b = 0; b < a.length; b++) c = a[b], c.start > h && g.push({
                start: h,
                end: c.start
            }), h = c.end;
            return f > h && g.push({
                start: h,
                end: f
            }), g
        },
        sortEventSegs: function (a) {
            a.sort(ia(this, "compareEventSegs"))
        },
        compareEventSegs: function (a, b) {
            return a.eventStartMS - b.eventStartMS || b.eventDurationMS - a.eventDurationMS || b.event.allDay - a.event.allDay || H(a.event, b.event, this.view.eventOrderSpecs)
        }
    }), Wa.isBgEvent = Da, Wa.dataAttrPrefix = "";
    var ub = Wa.DayTableMixin = {
        breakOnWeeks: !1,
        dayDates: null,
        dayIndices: null,
        daysPerRow: null,
        rowCnt: null,
        colCnt: null,
        colHeadFormat: null,
        updateDayTable: function () {
            for (var a, b, c, d = this.view, e = this.start.clone(), f = -1, g = [], h = []; e.isBefore(this.end) ;) d.isHiddenDay(e) ? g.push(f + .5) : (f++,
                g.push(f), h.push(e.clone())), e.add(1, "days");
            if (this.breakOnWeeks) {
                for (b = h[0].day(), a = 1; a < h.length && h[a].day() != b; a++);
                c = Math.ceil(h.length / a)
            } else c = 1, a = h.length;
            this.dayDates = h, this.dayIndices = g, this.daysPerRow = a, this.rowCnt = c, this.updateDayTableCols()
        },
        updateDayTableCols: function () {
            this.colCnt = this.computeColCnt(), this.colHeadFormat = this.view.opt("columnFormat") || this.computeColHeadFormat()
        },
        computeColCnt: function () {
            return this.daysPerRow
        },
        getCellDate: function (a, b) {
            return this.dayDates[this.getCellDayIndex(a, b)].clone()
        },
        getCellRange: function (a, b) {
            var c = this.getCellDate(a, b),
                d = c.clone().add(1, "days");
            return {
                start: c,
                end: d
            }
        },
        getCellDayIndex: function (a, b) {
            return a * this.daysPerRow + this.getColDayIndex(b)
        },
        getColDayIndex: function (a) {
            return this.isRTL ? this.colCnt - 1 - a : a
        },
        getDateDayIndex: function (a) {
            var b = this.dayIndices,
                c = a.diff(this.start, "days");
            return 0 > c ? b[0] - 1 : c >= b.length ? b[b.length - 1] + 1 : b[c]
        },
        computeColHeadFormat: function () {
            return this.rowCnt > 1 || this.colCnt > 10 ? "ddd" : this.colCnt > 1 ? this.view.opt("dayOfMonthFormat") : "dddd"
        },
        sliceRangeByRow: function (a) {
            var b, c, d, e, f, g = this.daysPerRow,
                h = this.view.computeDayRange(a),
                i = this.getDateDayIndex(h.start),
                j = this.getDateDayIndex(h.end.clone().subtract(1, "days")),
                k = [];
            for (b = 0; b < this.rowCnt; b++) c = b * g, d = c + g - 1, e = Math.max(i, c), f = Math.min(j, d), e = Math.ceil(e), f = Math.floor(f), f >= e && k.push({
                row: b,
                firstRowDayIndex: e - c,
                lastRowDayIndex: f - c,
                isStart: e === i,
                isEnd: f === j
            });
            return k
        },
        sliceRangeByDay: function (a) {
            var b, c, d, e, f, g, h = this.daysPerRow,
                i = this.view.computeDayRange(a),
                j = this.getDateDayIndex(i.start),
                k = this.getDateDayIndex(i.end.clone().subtract(1, "days")),
                l = [];
            for (b = 0; b < this.rowCnt; b++)
                for (c = b * h, d = c + h - 1, e = c; d >= e; e++) f = Math.max(j, e), g = Math.min(k, e), f = Math.ceil(f), g = Math.floor(g), g >= f && l.push({
                    row: b,
                    firstRowDayIndex: f - c,
                    lastRowDayIndex: g - c,
                    isStart: f === j,
                    isEnd: g === k
                });
            return l
        },
        renderHeadHtml: function () {
            var a = this.view;
            return '<div class="fc-row ' + a.widgetHeaderClass + '"><table><thead>' + this.renderHeadTrHtml() + "</thead></table></div>"
        },
        renderHeadIntroHtml: function () {
            return this.renderIntroHtml()
        },
        renderHeadTrHtml: function () {
            return "<tr>" + (this.isRTL ? "" : this.renderHeadIntroHtml()) + this.renderHeadDateCellsHtml() + (this.isRTL ? this.renderHeadIntroHtml() : "") + "</tr>"
        },
        renderHeadDateCellsHtml: function () {
            var a, b, c = [];
            for (a = 0; a < this.colCnt; a++) b = this.getCellDate(0, a), c.push(this.renderHeadDateCellHtml(b));
            return c.join("")
        },
        renderHeadDateCellHtml: function (a, b, c) {
            var d = this.view;
            return '<th class="fc-day-header ' + d.widgetHeaderClass + " fc-" + $a[a.day()] + '"' + (1 == this.rowCnt ? ' data-date="' + a.format("YYYY-MM-DD") + '"' : "") + (b > 1 ? ' colspan="' + b + '"' : "") + (c ? " " + c : "") + ">" + ca(a.format(this.colHeadFormat)) + "</th>"
        },
        renderBgTrHtml: function (a) {
            return "<tr>" + (this.isRTL ? "" : this.renderBgIntroHtml(a)) + this.renderBgCellsHtml(a) + (this.isRTL ? this.renderBgIntroHtml(a) : "") + "</tr>"
        },
        renderBgIntroHtml: function (a) {
            return this.renderIntroHtml()
        },
        renderBgCellsHtml: function (a) {
            var b, c, d = [];
            for (b = 0; b < this.colCnt; b++) c = this.getCellDate(a, b), d.push(this.renderBgCellHtml(c));
            return d.join("")
        },
        renderBgCellHtml: function (a, b) {
            var c = this.view,
                d = this.getDayClasses(a);
            return d.unshift("fc-day", c.widgetContentClass), '<td class="' + d.join(" ") + '" data-date="' + a.format("YYYY-MM-DD") + '"' + (b ? " " + b : "") + "></td>"
        },
        renderIntroHtml: function () { },
        bookendCells: function (a) {
            var b = this.renderIntroHtml();
            b && (this.isRTL ? a.append(b) : a.prepend(b))
        }
    },
        vb = Wa.DayGrid = tb.extend(ub, {
            numbersVisible: !1,
            bottomCoordPadding: 0,
            rowEls: null,
            cellEls: null,
            helperEls: null,
            rowCoordCache: null,
            colCoordCache: null,
            renderDates: function (a) {
                var b, c, d = this.view,
                    e = this.rowCnt,
                    f = this.colCnt,
                    g = "";
                for (b = 0; e > b; b++) g += this.renderDayRowHtml(b, a);
                for (this.el.html(g), this.rowEls = this.el.find(".fc-row"), this.cellEls = this.el.find(".fc-day"), this.rowCoordCache = new pb({
                    els: this.rowEls,
                    isVertical: !0
                }), this.colCoordCache = new pb({
                    els: this.cellEls.slice(0, this.colCnt),
                    isHorizontal: !0
                }), b = 0; e > b; b++)
                    for (c = 0; f > c; c++) d.trigger("dayRender", null, this.getCellDate(b, c), this.getCellEl(b, c))
            },
            unrenderDates: function () {
                this.removeSegPopover()
            },
            renderBusinessHours: function () {
                var a = this.buildBusinessHourSegs(!0);
                this.renderFill("businessHours", a, "bgevent")
            },
            unrenderBusinessHours: function () {
                this.unrenderFill("businessHours")
            },
            renderDayRowHtml: function (a, b) {
                var c = this.view,
                    d = ["fc-row", "fc-week", c.widgetContentClass];
                return b && d.push("fc-rigid"), '<div class="' + d.join(" ") + '"><div class="fc-bg"><table>' + this.renderBgTrHtml(a) + '</table></div><div class="fc-content-skeleton"><table>' + (this.numbersVisible ? "<thead>" + this.renderNumberTrHtml(a) + "</thead>" : "") + "</table></div></div>"
            },
            renderNumberTrHtml: function (a) {
                return "<tr>" + (this.isRTL ? "" : this.renderNumberIntroHtml(a)) + this.renderNumberCellsHtml(a) + (this.isRTL ? this.renderNumberIntroHtml(a) : "") + "</tr>"
            },
            renderNumberIntroHtml: function (a) {
                return this.renderIntroHtml()
            },
            renderNumberCellsHtml: function (a) {
                var b, c, d = [];
                for (b = 0; b < this.colCnt; b++) c = this.getCellDate(a, b), d.push(this.renderNumberCellHtml(c));
                return d.join("")
            },
            renderNumberCellHtml: function (a) {
                var b;
                return this.view.dayNumbersVisible ? (b = this.getDayClasses(a), b.unshift("fc-day-number"), '<td class="' + b.join(" ") + '" data-date="' + a.format() + '">' + a.date() + "</td>") : "<td/>"
            },
            computeEventTimeFormat: function () {
                return this.view.opt("extraSmallTimeFormat")
            },
            computeDisplayEventEnd: function () {
                return 1 == this.colCnt
            },
            rangeUpdated: function () {
                this.updateDayTable()
            },
            spanToSegs: function (a) {
                var b, c, d = this.sliceRangeByRow(a);
                for (b = 0; b < d.length; b++) c = d[b], this.isRTL ? (c.leftCol = this.daysPerRow - 1 - c.lastRowDayIndex, c.rightCol = this.daysPerRow - 1 - c.firstRowDayIndex) : (c.leftCol = c.firstRowDayIndex, c.rightCol = c.lastRowDayIndex);
                return d
            },
            prepareHits: function () {
                this.colCoordCache.build(), this.rowCoordCache.build(), this.rowCoordCache.bottoms[this.rowCnt - 1] += this.bottomCoordPadding
            },
            releaseHits: function () {
                this.colCoordCache.clear(), this.rowCoordCache.clear()
            },
            queryHit: function (a, b) {
                if (this.colCoordCache.isLeftInBounds(a) && this.rowCoordCache.isTopInBounds(b)) {
                    var c = this.colCoordCache.getHorizontalIndex(a),
                        d = this.rowCoordCache.getVerticalIndex(b);
                    if (null != d && null != c) return this.getCellHit(d, c)
                }
            },
            getHitSpan: function (a) {
                return this.getCellRange(a.row, a.col)
            },
            getHitEl: function (a) {
                return this.getCellEl(a.row, a.col)
            },
            getCellHit: function (a, b) {
                return {
                    row: a,
                    col: b,
                    component: this,
                    left: this.colCoordCache.getLeftOffset(b),
                    right: this.colCoordCache.getRightOffset(b),
                    top: this.rowCoordCache.getTopOffset(a),
                    bottom: this.rowCoordCache.getBottomOffset(a)
                }
            },
            getCellEl: function (a, b) {
                return this.cellEls.eq(a * this.colCnt + b)
            },
            renderDrag: function (a, b) {
                return this.renderHighlight(this.eventToSpan(a)), b && b.component !== this ? this.renderEventLocationHelper(a, b) : void 0
            },
            unrenderDrag: function () {
                this.unrenderHighlight(), this.unrenderHelper()
            },
            renderEventResize: function (a, b) {
                return this.renderHighlight(this.eventToSpan(a)), this.renderEventLocationHelper(a, b)
            },
            unrenderEventResize: function () {
                this.unrenderHighlight(), this.unrenderHelper()
            },
            renderHelper: function (b, c) {
                var d, e = [],
                    f = this.eventToSegs(b);
                return f = this.renderFgSegEls(f), d = this.renderSegRows(f), this.rowEls.each(function (b, f) {
                    var g, h = a(f),
                        i = a('<div class="fc-helper-skeleton"><table/></div>');
                    g = c && c.row === b ? c.el.position().top : h.find(".fc-content-skeleton tbody").position().top, i.css("top", g).find("table").append(d[b].tbodyEl), h.append(i), e.push(i[0])
                }), this.helperEls = a(e)
            },
            unrenderHelper: function () {
                this.helperEls && (this.helperEls.remove(), this.helperEls = null)
            },
            fillSegTag: "td",
            renderFill: function (b, c, d) {
                var e, f, g, h = [];
                for (c = this.renderFillSegEls(b, c), e = 0; e < c.length; e++) f = c[e], g = this.renderFillRow(b, f, d), this.rowEls.eq(f.row).append(g), h.push(g[0]);
                return this.elsByFill[b] = a(h), c
            },
            renderFillRow: function (b, c, d) {
                var e, f, g = this.colCnt,
                    h = c.leftCol,
                    i = c.rightCol + 1;
                return d = d || b.toLowerCase(), e = a('<div class="fc-' + d + '-skeleton"><table><tr/></table></div>'), f = e.find("tr"), h > 0 && f.append('<td colspan="' + h + '"/>'), f.append(c.el.attr("colspan", i - h)), g > i && f.append('<td colspan="' + (g - i) + '"/>'), this.bookendCells(f), e
            }
        });
    vb.mixin({
        rowStructs: null,
        unrenderEvents: function () {
            this.removeSegPopover(), tb.prototype.unrenderEvents.apply(this, arguments)
        },
        getEventSegs: function () {
            return tb.prototype.getEventSegs.call(this).concat(this.popoverSegs || [])
        },
        renderBgSegs: function (b) {
            var c = a.grep(b, function (a) {
                return a.event.allDay
            });
            return tb.prototype.renderBgSegs.call(this, c)
        },
        renderFgSegs: function (b) {
            var c;
            return b = this.renderFgSegEls(b), c = this.rowStructs = this.renderSegRows(b), this.rowEls.each(function (b, d) {
                a(d).find(".fc-content-skeleton > table").append(c[b].tbodyEl)
            }), b
        },
        unrenderFgSegs: function () {
            for (var a, b = this.rowStructs || []; a = b.pop() ;) a.tbodyEl.remove();
            this.rowStructs = null
        },
        renderSegRows: function (a) {
            var b, c, d = [];
            for (b = this.groupSegRows(a), c = 0; c < b.length; c++) d.push(this.renderSegRow(c, b[c]));
            return d
        },


        fgSegHtml: function (a, b) {
           
            var c, d, e = this.view,
                f = a.event,
                g = e.isEventDraggable(f),
                h = !b && f.allDay && a.isStart && e.isEventResizableFromStart(f),
                i = !b && f.allDay && a.isEnd && e.isEventResizableFromEnd(f),
                j = this.getSegClasses(a, g, h || i),
                k = ea(this.getSegSkinCss(a)),
                l = "";

            var jobTxt = f.description != '' && f.title > 0 ? 'Jobs' : ''
            var laborTxt = f.description != '' && f.title > 0 ? 'Labor' : ''

            return j.unshift("fc-day-grid-event", "fc-h-event"), a.isStart && (c = this.getEventTimeText(f) /*, c && (l = '<span class="fc-time">' + ca(c) + "</span>")*/), d = '<span class="fc-title">' + f.Shows + '<div class="calBottom"><div class="pull-left"><h4 style="color:black !important;">' + (ca(f.title || " ") || " ") + '<span>' + jobTxt + '</span></h4></div><div class="pull-right"><h4 style="color:black !important;">' + f.description/*(ca(f.description || " ") || " ")*/ + '<span>' + laborTxt + '</span></h4></div></div></span>', '<a class="' + j.join(" ") + '"' + (f.url ? ' href="' + ca(f.url) + '"' : "") + (k ? ' style="' + k + '"' : "") + '><div class="fc-content">' + (this.isRTL ? d + " " + l : l + " " + d) + "</div>" + (h ? '<div class="fc-resizer fc-start-resizer" />' : "") + (i ? '<div class="fc-resizer fc-end-resizer" />' : "") + "</a>"
        },
        renderSegRow: function (b, c) {
            function d(b) {
                for (; b > g;) k = (r[e - 1] || [])[g], k ? k.attr("rowspan", parseInt(k.attr("rowspan") || 1, 10) + 1) : (k = a("<td/>"), h.append(k)), q[e][g] = k, r[e][g] = k, g++
            }
            var e, f, g, h, i, j, k, l = this.colCnt,
                m = this.buildSegLevels(c),
                n = Math.max(1, m.length),
                o = a("<tbody/>"),
                p = [],
                q = [],
                r = [];
            for (e = 0; n > e; e++) {
                if (f = m[e], g = 0, h = a("<tr/>"), p.push([]), q.push([]), r.push([]), f)
                    for (i = 0; i < f.length; i++) {
                        for (j = f[i], d(j.leftCol), k = a('<td class="fc-event-container"/>').append(j.el), j.leftCol != j.rightCol ? k.attr("colspan", j.rightCol - j.leftCol + 1) : r[e][g] = k; g <= j.rightCol;) q[e][g] = k, p[e][g] = j, g++;
                        h.append(k)
                    }
                d(l), this.bookendCells(h), o.append(h)
            }
            return {
                row: b,
                tbodyEl: o,
                cellMatrix: q,
                segMatrix: p,
                segLevels: m,
                segs: c
            }
        },
        buildSegLevels: function (a) {
            var b, c, d, e = [];
            for (this.sortEventSegs(a), b = 0; b < a.length; b++) {
                for (c = a[b], d = 0; d < e.length && Ja(c, e[d]) ; d++);
                c.level = d, (e[d] || (e[d] = [])).push(c)
            }
            for (d = 0; d < e.length; d++) e[d].sort(Ka);
            return e
        },
        groupSegRows: function (a) {
            var b, c = [];
            for (b = 0; b < this.rowCnt; b++) c.push([]);
            for (b = 0; b < a.length; b++) c[a[b].row].push(a[b]);
            return c
        }
    }), vb.mixin({
        segPopover: null,
        popoverSegs: null,
        removeSegPopover: function () {
            this.segPopover && this.segPopover.hide()
        },
        limitRows: function (a) {
            var b, c, d = this.rowStructs || [];
            for (b = 0; b < d.length; b++) this.unlimitRow(b), c = a ? "number" == typeof a ? a : this.computeRowLevelLimit(b) : !1, c !== !1 && this.limitRow(b, c)
        },
        computeRowLevelLimit: function (b) {
            function c(b, c) {
                f = Math.max(f, a(c).outerHeight())
            }
            var d, e, f, g = this.rowEls.eq(b),
                h = g.height(),
                i = this.rowStructs[b].tbodyEl.children();
            for (d = 0; d < i.length; d++)
                if (e = i.eq(d).removeClass("fc-limited"), f = 0, e.find("> td > :first-child").each(c), e.position().top + f > h) return d;
            return !1
        },
        limitRow: function (b, c) {
            function d(d) {
                for (; d > w;) j = t.getCellSegs(b, w, c), j.length && (m = f[c - 1][w], s = t.renderMoreLink(b, w, j), r = a("<div/>").append(s), m.append(r), v.push(r[0])), w++
            }
            var e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t = this,
                u = this.rowStructs[b],
                v = [],
                w = 0;
            if (c && c < u.segLevels.length) {
                for (e = u.segLevels[c - 1], f = u.cellMatrix, g = u.tbodyEl.children().slice(c).addClass("fc-limited").get(), h = 0; h < e.length; h++) {
                    for (i = e[h], d(i.leftCol), l = [], k = 0; w <= i.rightCol;) j = this.getCellSegs(b, w, c), l.push(j), k += j.length, w++;
                    if (k) {
                        for (m = f[c - 1][i.leftCol], n = m.attr("rowspan") || 1, o = [], p = 0; p < l.length; p++) q = a('<td class="fc-more-cell"/>').attr("rowspan", n), j = l[p], s = this.renderMoreLink(b, i.leftCol + p, [i].concat(j)), r = a("<div/>").append(s), q.append(r), o.push(q[0]), v.push(q[0]);
                        m.addClass("fc-limited").after(a(o)), g.push(m[0])
                    }
                }
                d(this.colCnt), u.moreEls = a(v), u.limitedEls = a(g)
            }
        },
        unlimitRow: function (a) {
            var b = this.rowStructs[a];
            b.moreEls && (b.moreEls.remove(), b.moreEls = null), b.limitedEls && (b.limitedEls.removeClass("fc-limited"), b.limitedEls = null)
        },
        renderMoreLink: function (b, c, d) {
            var e = this,
                f = this.view;
            return a('<a class="fc-more"/>').text(this.getMoreLinkText(d.length)).on("click", function (g) {
                var h = f.opt("eventLimitClick"),
                    i = e.getCellDate(b, c),
                    j = a(this),
                    k = e.getCellEl(b, c),
                    l = e.getCellSegs(b, c),
                    m = e.resliceDaySegs(l, i),
                    n = e.resliceDaySegs(d, i);
                "function" == typeof h && (h = f.trigger("eventLimitClick", null, {
                    date: i,
                    dayEl: k,
                    moreEl: j,
                    segs: m,
                    hiddenSegs: n
                }, g)), "popover" === h ? e.showSegPopover(b, c, j, m) : "string" == typeof h && f.calendar.zoomTo(i, h)
            })
        },
        showSegPopover: function (a, b, c, d) {
            var e, f, g = this,
                h = this.view,
                i = c.parent();
            e = 1 == this.rowCnt ? h.el : this.rowEls.eq(a), f = {
                className: "fc-more-popover",
                content: this.renderSegPopoverContent(a, b, d),
                parentEl: this.view.el,
                top: e.offset().top,
                autoHide: !0,
                viewportConstrain: h.opt("popoverViewportConstrain"),
                hide: function () {
                    g.segPopover.removeElement(), g.segPopover = null, g.popoverSegs = null
                }
            }, this.isRTL ? f.right = i.offset().left + i.outerWidth() + 1 : f.left = i.offset().left - 1, this.segPopover = new ob(f), this.segPopover.show(), this.bindSegHandlersToEl(this.segPopover.el)
        },
        renderSegPopoverContent: function (b, c, d) {
            var e, f = this.view,
                g = f.opt("theme"),
                h = this.getCellDate(b, c).format(f.opt("dayPopoverFormat")),
                i = a('<div class="fc-header ' + f.widgetHeaderClass + '"><span class="fc-close ' + (g ? "ui-icon ui-icon-closethick" : "fc-icon fc-icon-x") + '"></span><span class="fc-title">' + ca(h) + '</span><div class="fc-clear"/></div><div class="fc-body ' + f.widgetContentClass + '"><div class="fc-event-container"></div></div>'),
                j = i.find(".fc-event-container");
            for (d = this.renderFgSegEls(d, !0), this.popoverSegs = d, e = 0; e < d.length; e++) this.prepareHits(), d[e].hit = this.getCellHit(b, c), this.releaseHits(), j.append(d[e].el);
            return i
        },
        resliceDaySegs: function (b, c) {
            var d = a.map(b, function (a) {
                return a.event
            }),
                e = c.clone(),
                f = e.clone().add(1, "days"),
                g = {
                    start: e,
                    end: f
                };
            return b = this.eventsToSegs(d, function (a) {
                var b = K(a, g);
                return b ? [b] : []
            }), this.sortEventSegs(b), b
        },
        getMoreLinkText: function (a) {
            var b = this.view.opt("eventLimitText");
            return "function" == typeof b ? b(a) : "+" + a + " " + b
        },
        getCellSegs: function (a, b, c) {
            for (var d, e = this.rowStructs[a].segMatrix, f = c || 0, g = []; f < e.length;) d = e[f][b], d && g.push(d), f++;
            return g
        }
    });
    var wb = Wa.TimeGrid = tb.extend(ub, {
        slotDuration: null,
        snapDuration: null,
        snapsPerSlot: null,
        minTime: null,
        maxTime: null,
        labelFormat: null,
        labelInterval: null,
        colEls: null,
        slatContainerEl: null,
        slatEls: null,
        nowIndicatorEls: null,
        colCoordCache: null,
        slatCoordCache: null,
        constructor: function () {
            tb.apply(this, arguments), this.processOptions()
        },
        renderDates: function () {
            this.el.html(this.renderHtml()), this.colEls = this.el.find(".fc-day"), this.slatContainerEl = this.el.find(".fc-slats"), this.slatEls = this.slatContainerEl.find("tr"), this.colCoordCache = new pb({
                els: this.colEls,
                isHorizontal: !0
            }), this.slatCoordCache = new pb({
                els: this.slatEls,
                isVertical: !0
            }), this.renderContentSkeleton()
        },
        renderHtml: function () {
            return '<div class="fc-bg"><table>' + this.renderBgTrHtml(0) + '</table></div><div class="fc-slats"><table>' + this.renderSlatRowHtml() + "</table></div>"
        },
        renderSlatRowHtml: function () {
            for (var a, c, d, e = this.view, f = this.isRTL, g = "", h = b.duration(+this.minTime) ; h < this.maxTime;) a = this.start.clone().time(h), c = ha(R(h, this.labelInterval)), d = '<td class="fc-axis fc-time ' + e.widgetContentClass + '" ' + e.axisStyleAttr() + ">" + (c ? "<span>" + ca(a.format(this.labelFormat)) + "</span>" : "") + "</td>", g += '<tr data-time="' + a.format("HH:mm:ss") + '"' + (c ? "" : ' class="fc-minor"') + ">" + (f ? "" : d) + '<td class="' + e.widgetContentClass + '"/>' + (f ? d : "") + "</tr>", h.add(this.slotDuration);
            return g
        },
        processOptions: function () {
            var c, d = this.view,
                e = d.opt("slotDuration"),
                f = d.opt("snapDuration");
            e = b.duration(e), f = f ? b.duration(f) : e, this.slotDuration = e, this.snapDuration = f, this.snapsPerSlot = e / f, this.minResizeDuration = f, this.minTime = b.duration(d.opt("minTime")), this.maxTime = b.duration(d.opt("maxTime")), c = d.opt("slotLabelFormat"), a.isArray(c) && (c = c[c.length - 1]), this.labelFormat = c || d.opt("axisFormat") || d.opt("smallTimeFormat"), c = d.opt("slotLabelInterval"), this.labelInterval = c ? b.duration(c) : this.computeLabelInterval(e)
        },
        computeLabelInterval: function (a) {
            var c, d, e;
            for (c = Ob.length - 1; c >= 0; c--)
                if (d = b.duration(Ob[c]), e = R(d, a), ha(e) && e > 1) return d;
            return b.duration(a)
        },
        computeEventTimeFormat: function () {
            return this.view.opt("noMeridiemTimeFormat")
        },
        computeDisplayEventEnd: function () {
            return !0
        },
        prepareHits: function () {
            this.colCoordCache.build(), this.slatCoordCache.build()
        },
        releaseHits: function () {
            this.colCoordCache.clear()
        },
        queryHit: function (a, b) {
            var c = this.snapsPerSlot,
                d = this.colCoordCache,
                e = this.slatCoordCache;
            if (d.isLeftInBounds(a) && e.isTopInBounds(b)) {
                var f = d.getHorizontalIndex(a),
                    g = e.getVerticalIndex(b);
                if (null != f && null != g) {
                    var h = e.getTopOffset(g),
                        i = e.getHeight(g),
                        j = (b - h) / i,
                        k = Math.floor(j * c),
                        l = g * c + k,
                        m = h + k / c * i,
                        n = h + (k + 1) / c * i;
                    return {
                        col: f,
                        snap: l,
                        component: this,
                        left: d.getLeftOffset(f),
                        right: d.getRightOffset(f),
                        top: m,
                        bottom: n
                    }
                }
            }
        },
        getHitSpan: function (a) {
            var b, c = this.getCellDate(0, a.col),
                d = this.computeSnapTime(a.snap);
            return c.time(d), b = c.clone().add(this.snapDuration), {
                start: c,
                end: b
            }
        },
        getHitEl: function (a) {
            return this.colEls.eq(a.col)
        },
        rangeUpdated: function () {
            this.updateDayTable()
        },
        computeSnapTime: function (a) {
            return b.duration(this.minTime + this.snapDuration * a)
        },
        spanToSegs: function (a) {
            var b, c = this.sliceRangeByTimes(a);
            for (b = 0; b < c.length; b++) this.isRTL ? c[b].col = this.daysPerRow - 1 - c[b].dayIndex : c[b].col = c[b].dayIndex;
            return c
        },
        sliceRangeByTimes: function (a) {
            var b, c, d, e, f = [];
            for (c = 0; c < this.daysPerRow; c++) d = this.dayDates[c].clone(), e = {
                start: d.clone().time(this.minTime),
                end: d.clone().time(this.maxTime)
            }, b = K(a, e), b && (b.dayIndex = c, f.push(b));
            return f
        },
        updateSize: function (a) {
            this.slatCoordCache.build(), a && this.updateSegVerticals([].concat(this.fgSegs || [], this.bgSegs || [], this.businessSegs || []))
        },
        getTotalSlatHeight: function () {
            return this.slatContainerEl.outerHeight()
        },
        computeDateTop: function (a, c) {
            return this.computeTimeTop(b.duration(a - c.clone().stripTime()))
        },
        computeTimeTop: function (a) {
            var b, c, d = this.slatEls.length,
                e = (a - this.minTime) / this.slotDuration;
            return e = Math.max(0, e), e = Math.min(d, e), b = Math.floor(e), b = Math.min(b, d - 1), c = e - b, this.slatCoordCache.getTopPosition(b) + this.slatCoordCache.getHeight(b) * c
        },
        renderDrag: function (a, b) {
            return b ? this.renderEventLocationHelper(a, b) : void this.renderHighlight(this.eventToSpan(a))
        },
        unrenderDrag: function () {
            this.unrenderHelper(), this.unrenderHighlight()
        },
        renderEventResize: function (a, b) {
            return this.renderEventLocationHelper(a, b)
        },
        unrenderEventResize: function () {
            this.unrenderHelper()
        },
        renderHelper: function (a, b) {
            return this.renderHelperSegs(this.eventToSegs(a), b)
        },
        unrenderHelper: function () {
            this.unrenderHelperSegs()
        },
        renderBusinessHours: function () {
            this.renderBusinessSegs(this.buildBusinessHourSegs())
        },
        unrenderBusinessHours: function () {
            this.unrenderBusinessSegs()
        },
        getNowIndicatorUnit: function () {
            return "minute"
        },
        renderNowIndicator: function (b) {
            var c, d = this.spanToSegs({
                start: b,
                end: b
            }),
                e = this.computeDateTop(b, b),
                f = [];
            for (c = 0; c < d.length; c++) f.push(a('<div class="fc-now-indicator fc-now-indicator-line"></div>').css("top", e).appendTo(this.colContainerEls.eq(d[c].col))[0]);
            d.length > 0 && f.push(a('<div class="fc-now-indicator fc-now-indicator-arrow"></div>').css("top", e).appendTo(this.el.find(".fc-content-skeleton"))[0]), this.nowIndicatorEls = a(f)
        },
        unrenderNowIndicator: function () {
            this.nowIndicatorEls && (this.nowIndicatorEls.remove(), this.nowIndicatorEls = null)
        },
        renderSelection: function (a) {
            this.view.opt("selectHelper") ? this.renderEventLocationHelper(a) : this.renderHighlight(a)
        },
        unrenderSelection: function () {
            this.unrenderHelper(), this.unrenderHighlight()
        },
        renderHighlight: function (a) {
            this.renderHighlightSegs(this.spanToSegs(a))
        },
        unrenderHighlight: function () {
            this.unrenderHighlightSegs()
        }
    });
    wb.mixin({
        colContainerEls: null,
        fgContainerEls: null,
        bgContainerEls: null,
        helperContainerEls: null,
        highlightContainerEls: null,
        businessContainerEls: null,
        fgSegs: null,
        bgSegs: null,
        helperSegs: null,
        highlightSegs: null,
        businessSegs: null,
        renderContentSkeleton: function () {
            var b, c, d = "";
            for (b = 0; b < this.colCnt; b++) d += '<td><div class="fc-content-col"><div class="fc-event-container fc-helper-container"></div><div class="fc-event-container"></div><div class="fc-highlight-container"></div><div class="fc-bgevent-container"></div><div class="fc-business-container"></div></div></td>';
            c = a('<div class="fc-content-skeleton"><table><tr>' + d + "</tr></table></div>"), this.colContainerEls = c.find(".fc-content-col"), this.helperContainerEls = c.find(".fc-helper-container"), this.fgContainerEls = c.find(".fc-event-container:not(.fc-helper-container)"), this.bgContainerEls = c.find(".fc-bgevent-container"), this.highlightContainerEls = c.find(".fc-highlight-container"), this.businessContainerEls = c.find(".fc-business-container"), this.bookendCells(c.find("tr")), this.el.append(c)
        },
        renderFgSegs: function (a) {
            return a = this.renderFgSegsIntoContainers(a, this.fgContainerEls), this.fgSegs = a, a
        },
        unrenderFgSegs: function () {
            this.unrenderNamedSegs("fgSegs")
        },
        renderHelperSegs: function (b, c) {
            var d, e, f, g = [];
            for (b = this.renderFgSegsIntoContainers(b, this.helperContainerEls), d = 0; d < b.length; d++) e = b[d], c && c.col === e.col && (f = c.el, e.el.css({
                left: f.css("left"),
                right: f.css("right"),
                "margin-left": f.css("margin-left"),
                "margin-right": f.css("margin-right")
            })), g.push(e.el[0]);
            return this.helperSegs = b, a(g)
        },
        unrenderHelperSegs: function () {
            this.unrenderNamedSegs("helperSegs")
        },
        renderBgSegs: function (a) {
            return a = this.renderFillSegEls("bgEvent", a), this.updateSegVerticals(a), this.attachSegsByCol(this.groupSegsByCol(a), this.bgContainerEls), this.bgSegs = a, a
        },
        unrenderBgSegs: function () {
            this.unrenderNamedSegs("bgSegs")
        },
        renderHighlightSegs: function (a) {
            a = this.renderFillSegEls("highlight", a), this.updateSegVerticals(a), this.attachSegsByCol(this.groupSegsByCol(a), this.highlightContainerEls), this.highlightSegs = a
        },
        unrenderHighlightSegs: function () {
            this.unrenderNamedSegs("highlightSegs")
        },
        renderBusinessSegs: function (a) {
            a = this.renderFillSegEls("businessHours", a), this.updateSegVerticals(a), this.attachSegsByCol(this.groupSegsByCol(a), this.businessContainerEls), this.businessSegs = a
        },
        unrenderBusinessSegs: function () {
            this.unrenderNamedSegs("businessSegs")
        },
        groupSegsByCol: function (a) {
            var b, c = [];
            for (b = 0; b < this.colCnt; b++) c.push([]);
            for (b = 0; b < a.length; b++) c[a[b].col].push(a[b]);
            return c
        },
        attachSegsByCol: function (a, b) {
            var c, d, e;
            for (c = 0; c < this.colCnt; c++)
                for (d = a[c], e = 0; e < d.length; e++) b.eq(c).append(d[e].el)
        },
        unrenderNamedSegs: function (a) {
            var b, c = this[a];
            if (c) {
                for (b = 0; b < c.length; b++) c[b].el.remove();
                this[a] = null
            }
        },
        renderFgSegsIntoContainers: function (a, b) {
            var c, d;
            for (a = this.renderFgSegEls(a), c = this.groupSegsByCol(a), d = 0; d < this.colCnt; d++) this.updateFgSegCoords(c[d]);
            return this.attachSegsByCol(c, b), a
        },
        fgSegHtml: function (a, b) {
            var c, d, e, f = this.view,
                g = a.event,
                h = f.isEventDraggable(g),
                i = !b && a.isStart && f.isEventResizableFromStart(g),
                j = !b && a.isEnd && f.isEventResizableFromEnd(g),
                k = this.getSegClasses(a, h, i || j),
                l = ea(this.getSegSkinCss(a));
            return k.unshift("fc-time-grid-event", "fc-v-event"), f.isMultiDayEvent(g) ? (a.isStart || a.isEnd) && (c = this.getEventTimeText(a), d = this.getEventTimeText(a, "LT"), e = this.getEventTimeText(a, null, !1)) : (c = this.getEventTimeText(g), d = this.getEventTimeText(g, "LT"), e = this.getEventTimeText(g, null, !1)), '<a class="' + k.join(" ") + '"' + (g.url ? ' href="' + ca(g.url) + '"' : "") + (l ? ' style="' + l + '"' : "") + '><div class="fc-content">' + (c ? '<div class="fc-time" data-start="' + ca(e) + '" data-full="' + ca(d) + '"><span>' + ca(c) + "</span></div>" : "") + (g.title ? '<div class="fc-title">' + ca(g.title) + "</div>" : "") + '</div><div class="fc-bg"/>' + (j ? '<div class="fc-resizer fc-end-resizer" />' : "") + "</a>"
        },
        updateSegVerticals: function (a) {
            this.computeSegVerticals(a), this.assignSegVerticals(a)
        },
        computeSegVerticals: function (a) {
            var b, c;
            for (b = 0; b < a.length; b++) c = a[b], c.top = this.computeDateTop(c.start, c.start), c.bottom = this.computeDateTop(c.end, c.start)
        },
        assignSegVerticals: function (a) {
            var b, c;
            for (b = 0; b < a.length; b++) c = a[b], c.el.css(this.generateSegVerticalCss(c))
        },
        generateSegVerticalCss: function (a) {
            return {
                top: a.top,
                bottom: -a.bottom
            }
        },
        updateFgSegCoords: function (a) {
            this.computeSegVerticals(a), this.computeFgSegHorizontals(a), this.assignSegVerticals(a), this.assignFgSegHorizontals(a)
        },
        computeFgSegHorizontals: function (a) {
            var b, c, d;
            if (this.sortEventSegs(a), b = La(a), Ma(b), c = b[0]) {
                for (d = 0; d < c.length; d++) Na(c[d]);
                for (d = 0; d < c.length; d++) this.computeFgSegForwardBack(c[d], 0, 0)
            }
        },
        computeFgSegForwardBack: function (a, b, c) {
            var d, e = a.forwardSegs;
            if (void 0 === a.forwardCoord)
                for (e.length ? (this.sortForwardSegs(e), this.computeFgSegForwardBack(e[0], b + 1, c), a.forwardCoord = e[0].backwardCoord) : a.forwardCoord = 1, a.backwardCoord = a.forwardCoord - (a.forwardCoord - c) / (b + 1), d = 0; d < e.length; d++) this.computeFgSegForwardBack(e[d], 0, a.forwardCoord)
        },
        sortForwardSegs: function (a) {
            a.sort(ia(this, "compareForwardSegs"))
        },
        compareForwardSegs: function (a, b) {
            return b.forwardPressure - a.forwardPressure || (a.backwardCoord || 0) - (b.backwardCoord || 0) || this.compareEventSegs(a, b)
        },
        assignFgSegHorizontals: function (a) {
            var b, c;
            for (b = 0; b < a.length; b++) c = a[b], c.el.css(this.generateFgSegHorizontalCss(c)), c.bottom - c.top < 30 && c.el.addClass("fc-short")
        },
        generateFgSegHorizontalCss: function (a) {
            var b, c, d = this.view.opt("slotEventOverlap"),
                e = a.backwardCoord,
                f = a.forwardCoord,
                g = this.generateSegVerticalCss(a);
            return d && (f = Math.min(1, e + 2 * (f - e))), this.isRTL ? (b = 1 - f, c = e) : (b = e, c = 1 - f), g.zIndex = a.level + 1, g.left = 100 * b + "%", g.right = 100 * c + "%", d && a.forwardPressure && (g[this.isRTL ? "marginLeft" : "marginRight"] = 20), g
        }
    });
    var xb = Wa.View = ya.extend(lb, mb, {
        type: null,
        name: null,
        title: null,
        calendar: null,
        options: null,
        el: null,
        displaying: null,
        isSkeletonRendered: !1,
        isEventsRendered: !1,
        start: null,
        end: null,
        intervalStart: null,
        intervalEnd: null,
        intervalDuration: null,
        intervalUnit: null,
        isRTL: !1,
        isSelected: !1,
        selectedEvent: null,
        eventOrderSpecs: null,
        widgetHeaderClass: null,
        widgetContentClass: null,
        highlightStateClass: null,
        nextDayThreshold: null,
        isHiddenDayHash: null,
        isNowIndicatorRendered: null,
        initialNowDate: null,
        initialNowQueriedMs: null,
        nowIndicatorTimeoutID: null,
        nowIndicatorIntervalID: null,
        constructor: function (a, c, d, e) {
            this.calendar = a, this.type = this.name = c, this.options = d, this.intervalDuration = e || b.duration(1, "day"), this.nextDayThreshold = b.duration(this.opt("nextDayThreshold")), this.initThemingProps(), this.initHiddenDays(), this.isRTL = this.opt("isRTL"), this.eventOrderSpecs = G(this.opt("eventOrder")), this.initialize()
        },
        initialize: function () { },
        opt: function (a) {
            return this.options[a]
        },
        trigger: function (a, b) {
            var c = this.calendar;
            return c.trigger.apply(c, [a, b || this].concat(Array.prototype.slice.call(arguments, 2), [this]))
        },
        setDate: function (a) {
            this.setRange(this.computeRange(a))
        },
        setRange: function (b) {
            a.extend(this, b), this.updateTitle()
        },
        computeRange: function (a) {
            var b, c, d = O(this.intervalDuration),
                e = a.clone().startOf(d),
                f = e.clone().add(this.intervalDuration);
            return /year|month|week|day/.test(d) ? (e.stripTime(), f.stripTime()) : (e.hasTime() || (e = this.calendar.time(0)), f.hasTime() || (f = this.calendar.time(0))), b = e.clone(), b = this.skipHiddenDays(b), c = f.clone(), c = this.skipHiddenDays(c, -1, !0), {
                intervalUnit: d,
                intervalStart: e,
                intervalEnd: f,
                start: b,
                end: c
            }
        },
        computePrevDate: function (a) {
            return this.massageCurrentDate(a.clone().startOf(this.intervalUnit).subtract(this.intervalDuration), -1)
        },
        computeNextDate: function (a) {
            return this.massageCurrentDate(a.clone().startOf(this.intervalUnit).add(this.intervalDuration))
        },
        massageCurrentDate: function (a, b) {
            return this.intervalDuration.as("days") <= 1 && this.isHiddenDay(a) && (a = this.skipHiddenDays(a, b), a.startOf("day")), a
        },
        updateTitle: function () {
            this.title = this.computeTitle()
        },
        computeTitle: function () {
            return this.formatRange({
                start: this.calendar.applyTimezone(this.intervalStart),
                end: this.calendar.applyTimezone(this.intervalEnd)
            }, this.opt("titleFormat") || this.computeTitleFormat(), this.opt("titleRangeSeparator"))
        },
        computeTitleFormat: function () {
            return "year" == this.intervalUnit ? "YYYY" : "month" == this.intervalUnit ? this.opt("monthYearFormat") : this.intervalDuration.as("days") > 1 ? "ll" : "LL"
        },
        formatRange: function (a, b, c) {
            var d = a.end;
            return d.hasTime() || (d = d.clone().subtract(1)), ta(a.start, d, b, c, this.opt("isRTL"))
        },
        setElement: function (a) {
            this.el = a, this.bindGlobalHandlers()
        },
        removeElement: function () {
            this.clear(), this.isSkeletonRendered && (this.unrenderSkeleton(), this.isSkeletonRendered = !1), this.unbindGlobalHandlers(), this.el.remove()
        },
        display: function (a, b) {
            var c = this,
                d = null;
            return null != b && this.displaying && (d = this.queryScroll()), this.calendar.freezeContentHeight(), ka(this.clear(), function () {
                return c.displaying = ka(c.displayView(a), function () {
                    null != b ? c.setScroll(b) : c.forceScroll(c.computeInitialScroll(d)), c.calendar.unfreezeContentHeight(), c.triggerRender()
                })
            })
        },
        clear: function () {
            var b = this,
                c = this.displaying;
            return c ? ka(c, function () {
                return b.displaying = null, b.clearEvents(), b.clearView()
            }) : a.when()
        },
        displayView: function (a) {
            this.isSkeletonRendered || (this.renderSkeleton(), this.isSkeletonRendered = !0), a && this.setDate(a), this.render && this.render(), this.renderDates(), this.updateSize(), this.renderBusinessHours(), this.startNowIndicator()
        },
        clearView: function () {
            this.unselect(), this.stopNowIndicator(), this.triggerUnrender(), this.unrenderBusinessHours(), this.unrenderDates(), this.destroy && this.destroy()
        },
        renderSkeleton: function () { },
        unrenderSkeleton: function () { },
        renderDates: function () { },
        unrenderDates: function () { },
        triggerRender: function () {
            this.trigger("viewRender", this, this, this.el)
        },
        triggerUnrender: function () {
            this.trigger("viewDestroy", this, this, this.el)
        },
        bindGlobalHandlers: function () {
            this.listenTo(a(document), "mousedown", this.handleDocumentMousedown), this.listenTo(a(document), "touchstart", this.processUnselect)
        },
        unbindGlobalHandlers: function () {
            this.stopListeningTo(a(document))
        },
        initThemingProps: function () {
            var a = this.opt("theme") ? "ui" : "fc";
            this.widgetHeaderClass = a + "-widget-header", this.widgetContentClass = a + "-widget-content", this.highlightStateClass = a + "-state-highlight"
        },
        renderBusinessHours: function () { },
        unrenderBusinessHours: function () { },
        startNowIndicator: function () {
            var a, c, d, e = this;
            this.opt("nowIndicator") && (a = this.getNowIndicatorUnit(), a && (c = ia(this, "updateNowIndicator"), this.initialNowDate = this.calendar.getNow(), this.initialNowQueriedMs = +new Date, this.renderNowIndicator(this.initialNowDate), this.isNowIndicatorRendered = !0, d = this.initialNowDate.clone().startOf(a).add(1, a) - this.initialNowDate, this.nowIndicatorTimeoutID = setTimeout(function () {
                e.nowIndicatorTimeoutID = null, c(), d = +b.duration(1, a), d = Math.max(100, d), e.nowIndicatorIntervalID = setInterval(c, d)
            }, d)))
        },
        updateNowIndicator: function () {
            this.isNowIndicatorRendered && (this.unrenderNowIndicator(), this.renderNowIndicator(this.initialNowDate.clone().add(new Date - this.initialNowQueriedMs)))
        },
        stopNowIndicator: function () {
            this.isNowIndicatorRendered && (this.nowIndicatorTimeoutID && (clearTimeout(this.nowIndicatorTimeoutID), this.nowIndicatorTimeoutID = null), this.nowIndicatorIntervalID && (clearTimeout(this.nowIndicatorIntervalID), this.nowIndicatorIntervalID = null), this.unrenderNowIndicator(), this.isNowIndicatorRendered = !1)
        },
        getNowIndicatorUnit: function () { },
        renderNowIndicator: function (a) { },
        unrenderNowIndicator: function () { },
        updateSize: function (a) {
            var b;
            a && (b = this.queryScroll()), this.updateHeight(a), this.updateWidth(a), this.updateNowIndicator(), a && this.setScroll(b)
        },
        updateWidth: function (a) { },
        updateHeight: function (a) {
            var b = this.calendar;
            this.setHeight(b.getSuggestedViewHeight(), b.isHeightAuto())
        },
        setHeight: function (a, b) { },
        computeInitialScroll: function (a) {
            return 0
        },
        queryScroll: function () { },
        setScroll: function (a) { },
        forceScroll: function (a) {
            var b = this;
            this.setScroll(a), setTimeout(function () {
                b.setScroll(a)
            }, 0)
        },
        displayEvents: function (a) {
            var b = this.queryScroll();
            this.clearEvents(), this.renderEvents(a), this.isEventsRendered = !0, this.setScroll(b), this.triggerEventRender()
        },
        clearEvents: function () {
            var a;
            this.isEventsRendered && (a = this.queryScroll(), this.triggerEventUnrender(), this.destroyEvents && this.destroyEvents(), this.unrenderEvents(), this.setScroll(a), this.isEventsRendered = !1)
        },
        renderEvents: function (a) { },
        unrenderEvents: function () { },
        triggerEventRender: function () {
            this.renderedEventSegEach(function (a) {
                this.trigger("eventAfterRender", a.event, a.event, a.el)
            }), this.trigger("eventAfterAllRender");
        },
        triggerEventUnrender: function () {
            this.renderedEventSegEach(function (a) {
                this.trigger("eventDestroy", a.event, a.event, a.el)
            })
        },
        resolveEventEl: function (b, c) {
            var d = this.trigger("eventRender", b, b, c);
            return d === !1 ? c = null : d && d !== !0 && (c = a(d)), c
        },
        showEvent: function (a) {
            this.renderedEventSegEach(function (a) {
                a.el.css("visibility", "")
            }, a)
        },
        hideEvent: function (a) {
            this.renderedEventSegEach(function (a) {
                a.el.css("visibility", "hidden")
            }, a)
        },
        renderedEventSegEach: function (a, b) {
            var c, d = this.getEventSegs();
            for (c = 0; c < d.length; c++) b && d[c].event._id !== b._id || d[c].el && a.call(this, d[c])
        },
        getEventSegs: function () {
            return []
        },
        isEventDraggable: function (a) {
            var b = a.source || {};
            return ba(a.startEditable, b.startEditable, this.opt("eventStartEditable"), a.editable, b.editable, this.opt("editable"))
        },
        reportEventDrop: function (a, b, c, d, e) {
            var f = this.calendar,
                g = f.mutateEvent(a, b, c),
                h = function () {
                    g.undo(), f.reportEventChange()
                };
            this.triggerEventDrop(a, g.dateDelta, h, d, e), f.reportEventChange()
        },
        triggerEventDrop: function (a, b, c, d, e) {
            this.trigger("eventDrop", d[0], a, b, c, e, {})
        },
        reportExternalDrop: function (b, c, d, e, f) {
            var g, h, i = b.eventProps;
            i && (g = a.extend({}, i, c), h = this.calendar.renderEvent(g, b.stick)[0]), this.triggerExternalDrop(h, c, d, e, f)
        },
        triggerExternalDrop: function (a, b, c, d, e) {
            this.trigger("drop", c[0], b.start, d, e), a && this.trigger("eventReceive", null, a)
        },
        renderDrag: function (a, b) { },
        unrenderDrag: function () { },
        isEventResizableFromStart: function (a) {
            return this.opt("eventResizableFromStart") && this.isEventResizable(a)
        },
        isEventResizableFromEnd: function (a) {
            return this.isEventResizable(a)
        },
        isEventResizable: function (a) {
            var b = a.source || {};
            return ba(a.durationEditable, b.durationEditable, this.opt("eventDurationEditable"), a.editable, b.editable, this.opt("editable"))
        },
        reportEventResize: function (a, b, c, d, e) {
            var f = this.calendar,
                g = f.mutateEvent(a, b, c),
                h = function () {
                    g.undo(), f.reportEventChange()
                };
            this.triggerEventResize(a, g.durationDelta, h, d, e), f.reportEventChange()
        },
        triggerEventResize: function (a, b, c, d, e) {
            this.trigger("eventResize", d[0], a, b, c, e, {})
        },
        select: function (a, b) {
            this.unselect(b), this.renderSelection(a), this.reportSelection(a, b)
        },
        renderSelection: function (a) { },
        reportSelection: function (a, b) {
            this.isSelected = !0, this.triggerSelect(a, b)
        },
        triggerSelect: function (a, b) {
            this.trigger("select", null, this.calendar.applyTimezone(a.start), this.calendar.applyTimezone(a.end), b)
        },
        unselect: function (a) {
            this.isSelected && (this.isSelected = !1, this.destroySelection && this.destroySelection(), this.unrenderSelection(), this.trigger("unselect", null, a))
        },
        unrenderSelection: function () { },
        selectEvent: function (a) {
            this.selectedEvent && this.selectedEvent === a || (this.unselectEvent(), this.renderedEventSegEach(function (a) {
                a.el.addClass("fc-selected")
            }, a), this.selectedEvent = a)
        },
        unselectEvent: function () {
            this.selectedEvent && (this.renderedEventSegEach(function (a) {
                a.el.removeClass("fc-selected")
            }, this.selectedEvent), this.selectedEvent = null)
        },
        isEventSelected: function (a) {
            return this.selectedEvent && this.selectedEvent._id === a._id
        },
        handleDocumentMousedown: function (a) {
            u(a) && this.processUnselect(a)
        },
        processUnselect: function (a) {
            this.processRangeUnselect(a), this.processEventUnselect(a)
        },
        processRangeUnselect: function (b) {
            var c;
            this.isSelected && this.opt("unselectAuto") && (c = this.opt("unselectCancel"), c && a(b.target).closest(c).length || this.unselect(b))
        },
        processEventUnselect: function (b) {
            this.selectedEvent && (a(b.target).closest(".fc-selected").length || this.unselectEvent())
        },
        triggerDayClick: function (a, b, c) {
            this.trigger("dayClick", b, this.calendar.applyTimezone(a.start), c)
        },
        initHiddenDays: function () {
            var b, c = this.opt("hiddenDays") || [],
                d = [],
                e = 0;
            for (this.opt("weekends") === !1 && c.push(0, 6), b = 0; 7 > b; b++) (d[b] = -1 !== a.inArray(b, c)) || e++;
            if (!e) throw "invalid hiddenDays";
            this.isHiddenDayHash = d
        },
        isHiddenDay: function (a) {
            return b.isMoment(a) && (a = a.day()), this.isHiddenDayHash[a]
        },
        skipHiddenDays: function (a, b, c) {
            var d = a.clone();
            for (b = b || 1; this.isHiddenDayHash[(d.day() + (c ? b : 0) + 7) % 7];) d.add(b, "days");
            return d
        },
        computeDayRange: function (a) {
            var b, c = a.start.clone().stripTime(),
                d = a.end,
                e = null;
            return d && (e = d.clone().stripTime(), b = +d.time(), b && b >= this.nextDayThreshold && e.add(1, "days")), (!d || c >= e) && (e = c.clone().add(1, "days")), {
                start: c,
                end: e
            }
        },
        isMultiDayEvent: function (a) {
            var b = this.computeDayRange(a);
            return b.end.diff(b.start, "days") > 1
        }
    }),
        yb = Wa.Scroller = ya.extend({
            el: null,
            scrollEl: null,
            overflowX: null,
            overflowY: null,
            constructor: function (a) {
                a = a || {}, this.overflowX = a.overflowX || a.overflow || "auto", this.overflowY = a.overflowY || a.overflow || "auto"
            },
            render: function () {
                this.el = this.renderEl(), this.applyOverflow()
            },
            renderEl: function () {
                return this.scrollEl = a('<div class="fc-scroller"></div>')
            },
            clear: function () {
                this.setHeight("auto"), this.applyOverflow()
            },
            destroy: function () {
                this.el.remove()
            },
            applyOverflow: function () {
                this.scrollEl.css({
                    "overflow-x": this.overflowX,
                    "overflow-y": this.overflowY
                })
            },
            lockOverflow: function (a) {
                var b = this.overflowX,
                    c = this.overflowY;
                a = a || this.getScrollbarWidths(), "auto" === b && (b = a.top || a.bottom || this.scrollEl[0].scrollWidth - 1 > this.scrollEl[0].clientWidth ? "scroll" : "hidden"), "auto" === c && (c = a.left || a.right || this.scrollEl[0].scrollHeight - 1 > this.scrollEl[0].clientHeight ? "scroll" : "hidden"), this.scrollEl.css({
                    "overflow-x": b,
                    "overflow-y": c
                })
            },
            setHeight: function (a) {
                this.scrollEl.height(a)
            },
            getScrollTop: function () {
                return this.scrollEl.scrollTop()
            },
            setScrollTop: function (a) {
                this.scrollEl.scrollTop(a)
            },
            getClientWidth: function () {
                return this.scrollEl[0].clientWidth
            },
            getClientHeight: function () {
                return this.scrollEl[0].clientHeight
            },
            getScrollbarWidths: function () {
                return q(this.scrollEl)
            }
        }),
        zb = Wa.Calendar = ya.extend({
            dirDefaults: null,
            langDefaults: null,
            overrides: null,
            dynamicOverrides: null,
            options: null,
            viewSpecCache: null,
            view: null,
            header: null,
            loadingLevel: 0,
            constructor: Qa,
            initialize: function () { },
            populateOptionsHash: function () {
                var a, b, d, e;
                a = ba(this.dynamicOverrides.lang, this.overrides.lang), b = Ab[a], b || (a = zb.defaults.lang, b = Ab[a] || {}), d = ba(this.dynamicOverrides.isRTL, this.overrides.isRTL, b.isRTL, zb.defaults.isRTL), e = d ? zb.rtlDefaults : {}, this.dirDefaults = e, this.langDefaults = b, this.options = c([zb.defaults, e, b, this.overrides, this.dynamicOverrides]), Ra(this.options)
            },
            getViewSpec: function (a) {
                var b = this.viewSpecCache;
                return b[a] || (b[a] = this.buildViewSpec(a))
            },
            getUnitViewSpec: function (b) {
                var c, d, e;
                if (-1 != a.inArray(b, _a))
                    for (c = this.header.getViewsWithButtons(), a.each(Wa.views, function (a) {
                            c.push(a)
                    }), d = 0; d < c.length; d++)
                        if (e = this.getViewSpec(c[d]), e && e.singleUnit == b) return e
            },
            buildViewSpec: function (a) {
                for (var d, e, f, g, h = this.overrides.views || {}, i = [], j = [], k = [], l = a; l;) d = Xa[l], e = h[l], l = null, "function" == typeof d && (d = {
                    "class": d
                }), d && (i.unshift(d), j.unshift(d.defaults || {}), f = f || d.duration, l = l || d.type), e && (k.unshift(e), f = f || e.duration, l = l || e.type);
                return d = W(i), d.type = a, d["class"] ? (f && (f = b.duration(f), f.valueOf() && (d.duration = f, g = O(f), 1 === f.as(g) && (d.singleUnit = g, k.unshift(h[g] || {})))), d.defaults = c(j), d.overrides = c(k), this.buildViewSpecOptions(d), this.buildViewSpecButtonText(d, a), d) : !1
            },
            buildViewSpecOptions: function (a) {
                a.options = c([zb.defaults, a.defaults, this.dirDefaults, this.langDefaults, this.overrides, a.overrides, this.dynamicOverrides]), Ra(a.options)
            },
            buildViewSpecButtonText: function (a, b) {
                function c(c) {
                    var d = c.buttonText || {};
                    return d[b] || (a.singleUnit ? d[a.singleUnit] : null)
                }
                a.buttonTextOverride = c(this.dynamicOverrides) || c(this.overrides) || a.overrides.buttonText, a.buttonTextDefault = c(this.langDefaults) || c(this.dirDefaults) || a.defaults.buttonText || c(zb.defaults) || (a.duration ? this.humanizeDuration(a.duration) : null) || b
            },
            instantiateView: function (a) {
                var b = this.getViewSpec(a);
                return new b["class"](this, a, b.options, b.duration)
            },
            isValidViewType: function (a) {
                return Boolean(this.getViewSpec(a))
            },
            pushLoading: function () {
                this.loadingLevel++ || this.trigger("loading", null, !0, this.view)
            },
            popLoading: function () {
                --this.loadingLevel || this.trigger("loading", null, !1, this.view)
            },
            buildSelectSpan: function (a, b) {
                var c, d = this.moment(a).stripZone();
                return c = b ? this.moment(b).stripZone() : d.hasTime() ? d.clone().add(this.defaultTimedEventDuration) : d.clone().add(this.defaultAllDayEventDuration), {
                    start: d,
                    end: c
                }
            }
        });
    zb.mixin(lb), zb.mixin({
        optionHandlers: null,
        bindOption: function (a, b) {
            this.bindOptions([a], b)
        },
        bindOptions: function (a, b) {
            var c, d = {
                func: b,
                names: a
            };
            for (c = 0; c < a.length; c++) this.registerOptionHandlerObj(a[c], d);
            this.triggerOptionHandlerObj(d)
        },
        registerOptionHandlerObj: function (a, b) {
            (this.optionHandlers[a] || (this.optionHandlers[a] = [])).push(b)
        },
        triggerOptionHandlers: function (a) {
            var b, c = this.optionHandlers[a] || [];
            for (b = 0; b < c.length; b++) this.triggerOptionHandlerObj(c[b])
        },
        triggerOptionHandlerObj: function (a) {
            var b, c = a.names,
                d = [];
            for (b = 0; b < c.length; b++) d.push(this.options[c[b]]);
            a.func.apply(this, d)
        }
    }), zb.defaults = {
        titleRangeSeparator: " â€“ ",
        monthYearFormat: "MMMM YYYY",
        defaultTimedEventDuration: "02:00:00",
        defaultAllDayEventDuration: {
            days: 1
        },
        forceEventDuration: !1,
        nextDayThreshold: "09:00:00",
        defaultView: "month",
        aspectRatio: 1.35,
        header: {
            left: "title",
            center: "",
            right: "today prev,next"
        },
        weekends: !0,
        weekNumbers: !1,
        weekNumberTitle: "W",
        weekNumberCalculation: "local",
        scrollTime: "06:00:00",
        lazyFetching: !0,
        startParam: "start",
        endParam: "end",
        timezoneParam: "timezone",
        timezone: !1,
        isRTL: !1,
        buttonText: {
            prev: "prev",
            next: "next",
            prevYear: "prev year",
            nextYear: "next year",
            year: "year",
            today: "today",
            month: "month",
            week: "week",
            day: "day"
        },
        buttonIcons: {
            prev: "left-single-arrow",
            next: "right-single-arrow",
            prevYear: "left-double-arrow",
            nextYear: "right-double-arrow"
        },
        theme: !1,
        themeButtonIcons: {
            prev: "circle-triangle-w",
            next: "circle-triangle-e",
            prevYear: "seek-prev",
            nextYear: "seek-next"
        },
        dragOpacity: .75,
        dragRevertDuration: 500,
        dragScroll: !0,
        unselectAuto: !0,
        dropAccept: "*",
        eventOrder: "title",
        eventLimit: !1,
        eventLimitText: "more",
        eventLimitClick: "popover",
        dayPopoverFormat: "LL",
        handleWindowResize: !0,
        windowResizeDelay: 100,
        longPressDelay: 1e3
    }, zb.englishDefaults = {
        dayPopoverFormat: "dddd, MMMM D"
    }, zb.rtlDefaults = {
        header: {
            left: "next,prev today",
            center: "",
            right: "title"
        },
        buttonIcons: {
            prev: "right-single-arrow",
            next: "left-single-arrow",
            prevYear: "right-double-arrow",
            nextYear: "left-double-arrow"
        },
        themeButtonIcons: {
            prev: "circle-triangle-e",
            next: "circle-triangle-w",
            nextYear: "seek-prev",
            prevYear: "seek-next"
        }
    };
    var Ab = Wa.langs = {};
    Wa.datepickerLang = function (b, c, d) {
        var e = Ab[b] || (Ab[b] = {});
        e.isRTL = d.isRTL, e.weekNumberTitle = d.weekHeader, a.each(Bb, function (a, b) {
            e[a] = b(d)
        }), a.datepicker && (a.datepicker.regional[c] = a.datepicker.regional[b] = d, a.datepicker.regional.en = a.datepicker.regional[""], a.datepicker.setDefaults(d))
    }, Wa.lang = function (b, d) {
        var e, f;
        e = Ab[b] || (Ab[b] = {}), d && (e = Ab[b] = c([e, d])), f = Sa(b), a.each(Cb, function (a, b) {
            null == e[a] && (e[a] = b(f, e))
        }), zb.defaults.lang = b
    };
    var Bb = {
        buttonText: function (a) {
            return {
                prev: da(a.prevText),
                next: da(a.nextText),
                today: da(a.currentText)
            }
        },
        monthYearFormat: function (a) {
            return a.showMonthAfterYear ? "YYYY[" + a.yearSuffix + "] MMMM" : "MMMM YYYY[" + a.yearSuffix + "]"
        }
    },
        Cb = {
            dayOfMonthFormat: function (a, b) {
                var c = a.longDateFormat("l");
                return c = c.replace(/^Y+[^\w\s]*|[^\w\s]*Y+$/g, ""), b.isRTL ? c += " ddd" : c = "ddd " + c, c
            },
            mediumTimeFormat: function (a) {
                return a.longDateFormat("LT").replace(/\s*a$/i, "a")
            },
            smallTimeFormat: function (a) {
                return a.longDateFormat("LT").replace(":mm", "(:mm)").replace(/(\Wmm)$/, "($1)").replace(/\s*a$/i, "a")
            },
            extraSmallTimeFormat: function (a) {
                return a.longDateFormat("LT").replace(":mm", "(:mm)").replace(/(\Wmm)$/, "($1)").replace(/\s*a$/i, "t")
            },
            hourFormat: function (a) {
                return a.longDateFormat("LT").replace(":mm", "").replace(/(\Wmm)$/, "").replace(/\s*a$/i, "a")
            },
            noMeridiemTimeFormat: function (a) {
                return a.longDateFormat("LT").replace(/\s*a$/i, "")
            }
        },
        Db = {
            smallDayDateFormat: function (a) {
                return a.isRTL ? "D dd" : "dd D"
            },
            weekFormat: function (a) {
                return a.isRTL ? "w[ " + a.weekNumberTitle + "]" : "[" + a.weekNumberTitle + " ]w"
            },
            smallWeekFormat: function (a) {
                return a.isRTL ? "w[" + a.weekNumberTitle + "]" : "[" + a.weekNumberTitle + "]w"
            }
        };
    Wa.lang("en", zb.englishDefaults), Wa.sourceNormalizers = [], Wa.sourceFetchers = [];
    var Eb = {
        dataType: "json",
        cache: !1
    },
        Fb = 1;
    zb.prototype.normalizeEvent = function (a) { }, zb.prototype.spanContainsSpan = function (a, b) {
        var c = a.start.clone().stripZone(),
            d = this.getEventEnd(a).stripZone();
        return b.start >= c && b.end <= d
    }, zb.prototype.getPeerEvents = function (a, b) {
        var c, d, e = this.getEventCache(),
            f = [];
        for (c = 0; c < e.length; c++) d = e[c], b && b._id === d._id || f.push(d);
        return f
    };
    var Gb = {
        id: "_fcBusinessHours",
        start: "09:00",
        end: "17:00",
        dow: [1, 2, 3, 4, 5],
        rendering: "inverse-background"
    };
    zb.prototype.getCurrentBusinessHourEvents = function (a) {
        return this.computeBusinessHourEvents(a, this.options.businessHours)
    }, zb.prototype.computeBusinessHourEvents = function (b, c) {
        return c === !0 ? this.expandBusinessHourEvents(b, [{}]) : a.isPlainObject(c) ? this.expandBusinessHourEvents(b, [c]) : a.isArray(c) ? this.expandBusinessHourEvents(b, c, !0) : []
    }, zb.prototype.expandBusinessHourEvents = function (b, c, d) {
        var e, f, g = this.getView(),
            h = [];
        for (e = 0; e < c.length; e++) f = c[e], d && !f.dow || (f = a.extend({}, Gb, f), b && (f.start = null, f.end = null), h.push.apply(h, this.expandEvent(this.buildEventFromInput(f), g.start, g.end)));
        return h
    };
    var Hb = Wa.BasicView = xb.extend({
        scroller: null,
        dayGridClass: vb,
        dayGrid: null,
        dayNumbersVisible: !1,
        weekNumbersVisible: !1,
        weekNumberWidth: null,
        headContainerEl: null,
        headRowEl: null,
        initialize: function () {
            this.dayGrid = this.instantiateDayGrid(), this.scroller = new yb({
                overflowX: "hidden",
                overflowY: "auto"
            })
        },
        instantiateDayGrid: function () {
            var a = this.dayGridClass.extend(Ib);
            return new a(this)
        },
        setRange: function (a) {
            xb.prototype.setRange.call(this, a), this.dayGrid.breakOnWeeks = /year|month|week/.test(this.intervalUnit), this.dayGrid.setRange(a)
        },
        computeRange: function (a) {
            var b = xb.prototype.computeRange.call(this, a);
            return /year|month/.test(b.intervalUnit) && (b.start.startOf("week"), b.start = this.skipHiddenDays(b.start), b.end.weekday() && (b.end.add(1, "week").startOf("week"), b.end = this.skipHiddenDays(b.end, -1, !0))), b
        },
        renderDates: function () {
            this.dayNumbersVisible = this.dayGrid.rowCnt > 1, this.weekNumbersVisible = this.opt("weekNumbers"), this.dayGrid.numbersVisible = this.dayNumbersVisible || this.weekNumbersVisible, this.el.addClass("fc-basic-view").html(this.renderSkeletonHtml()), this.renderHead(), this.scroller.render();
            var b = this.scroller.el.addClass("fc-day-grid-container"),
                c = a('<div class="fc-day-grid" />').appendTo(b);
            this.el.find(".fc-body > tr > td").append(b), this.dayGrid.setElement(c), this.dayGrid.renderDates(this.hasRigidRows())
        },
        renderHead: function () {
            this.headContainerEl = this.el.find(".fc-head-container").html(this.dayGrid.renderHeadHtml()), this.headRowEl = this.headContainerEl.find(".fc-row")
        },
        unrenderDates: function () {
            this.dayGrid.unrenderDates(), this.dayGrid.removeElement(), this.scroller.destroy()
        },
        renderBusinessHours: function () {
            this.dayGrid.renderBusinessHours()
        },
        unrenderBusinessHours: function () {
            this.dayGrid.unrenderBusinessHours()
        },
        renderSkeletonHtml: function () {
            return '<table><thead class="fc-head"><tr><td class="fc-head-container ' + this.widgetHeaderClass + '"></td></tr></thead><tbody class="fc-body"><tr><td class="' + this.widgetContentClass + '"></td></tr></tbody></table>'
        },
        weekNumberStyleAttr: function () {
            return null !== this.weekNumberWidth ? 'style="width:' + this.weekNumberWidth + 'px"' : ""
        },
        hasRigidRows: function () {
            var a = this.opt("eventLimit");
            return a && "number" != typeof a
        },
        updateWidth: function () {
            this.weekNumbersVisible && (this.weekNumberWidth = k(this.el.find(".fc-week-number")))
        },
        setHeight: function (a, b) {
            var c, d, g = this.opt("eventLimit");
            this.scroller.clear(), f(this.headRowEl), this.dayGrid.removeSegPopover(), g && "number" == typeof g && this.dayGrid.limitRows(g), c = this.computeScrollerHeight(a), this.setGridHeight(c, b), g && "number" != typeof g && this.dayGrid.limitRows(g), b || (this.scroller.setHeight(c), d = this.scroller.getScrollbarWidths(), (d.left || d.right) && (e(this.headRowEl, d), c = this.computeScrollerHeight(a), this.scroller.setHeight(c)), this.scroller.lockOverflow(d))
        },
        computeScrollerHeight: function (a) {
            return a - l(this.el, this.scroller.el)
        },
        setGridHeight: function (a, b) {
            b ? j(this.dayGrid.rowEls) : i(this.dayGrid.rowEls, a, !0)
        },
        queryScroll: function () {
            return this.scroller.getScrollTop()
        },
        setScroll: function (a) {
            this.scroller.setScrollTop(a)
        },
        prepareHits: function () {
            this.dayGrid.prepareHits()
        },
        releaseHits: function () {
            this.dayGrid.releaseHits()
        },
        queryHit: function (a, b) {
            return this.dayGrid.queryHit(a, b)
        },
        getHitSpan: function (a) {
            return this.dayGrid.getHitSpan(a)
        },
        getHitEl: function (a) {
            return this.dayGrid.getHitEl(a)
        },
        renderEvents: function (a) {
            this.dayGrid.renderEvents(a), this.updateHeight()
        },
        getEventSegs: function () {
            return this.dayGrid.getEventSegs()
        },
        unrenderEvents: function () {
            this.dayGrid.unrenderEvents()
        },
        renderDrag: function (a, b) {
            return this.dayGrid.renderDrag(a, b)
        },
        unrenderDrag: function () {
            this.dayGrid.unrenderDrag()
        },
        renderSelection: function (a) {
            this.dayGrid.renderSelection(a)
        },
        unrenderSelection: function () {
            this.dayGrid.unrenderSelection()
        }
    }),
        Ib = {
            renderHeadIntroHtml: function () {
                var a = this.view;
                return a.weekNumbersVisible ? '<th class="fc-week-number ' + a.widgetHeaderClass + '" ' + a.weekNumberStyleAttr() + "><span>" + ca(a.opt("weekNumberTitle")) + "</span></th>" : ""
            },
            renderNumberIntroHtml: function (a) {
                var b = this.view;
                return b.weekNumbersVisible ? '<td class="fc-week-number" ' + b.weekNumberStyleAttr() + "><span>" + this.getCellDate(a, 0).format("w") + "</span></td>" : ""
            },
            renderBgIntroHtml: function () {
                var a = this.view;
                return a.weekNumbersVisible ? '<td class="fc-week-number ' + a.widgetContentClass + '" ' + a.weekNumberStyleAttr() + "></td>" : ""
            },
            renderIntroHtml: function () {
                var a = this.view;
                return a.weekNumbersVisible ? '<td class="fc-week-number" ' + a.weekNumberStyleAttr() + "></td>" : ""
            }
        },
        Jb = Wa.MonthView = Hb.extend({
            computeRange: function (a) {
                var b, c = Hb.prototype.computeRange.call(this, a);
                return this.isFixedWeeks() && (b = Math.ceil(c.end.diff(c.start, "weeks", !0)), c.end.add(6 - b, "weeks")), c
            },
            setGridHeight: function (a, b) {
                b = b || "variable" === this.opt("weekMode"), b && (a *= this.rowCnt / 6), i(this.dayGrid.rowEls, a, !b)
            },
            isFixedWeeks: function () {
                var a = this.opt("weekMode");
                return a ? "fixed" === a : this.opt("fixedWeekCount")
            }
        });
    Xa.basic = {
        "class": Hb
    }, Xa.basicDay = {
        type: "basic",
        duration: {
            days: 1
        }
    }, Xa.basicWeek = {
        type: "basic",
        duration: {
            weeks: 1
        }
    }, Xa.month = {
        "class": Jb,
        duration: {
            months: 1
        },
        defaults: {
            fixedWeekCount: !0
        }
    };
    var Kb = Wa.AgendaView = xb.extend({
        scroller: null,
        timeGridClass: wb,
        timeGrid: null,
        dayGridClass: vb,
        dayGrid: null,
        axisWidth: null,
        headContainerEl: null,
        noScrollRowEls: null,
        bottomRuleEl: null,
        initialize: function () {
            this.timeGrid = this.instantiateTimeGrid(), this.opt("allDaySlot") && (this.dayGrid = this.instantiateDayGrid()), this.scroller = new yb({
                overflowX: "hidden",
                overflowY: "auto"
            })
        },
        instantiateTimeGrid: function () {
            var a = this.timeGridClass.extend(Lb);
            return new a(this)
        },
        instantiateDayGrid: function () {
            var a = this.dayGridClass.extend(Mb);
            return new a(this)
        },
        setRange: function (a) {
            xb.prototype.setRange.call(this, a), this.timeGrid.setRange(a), this.dayGrid && this.dayGrid.setRange(a)
        },
        renderDates: function () {
            this.el.addClass("fc-agenda-view").html(this.renderSkeletonHtml()), this.renderHead(), this.scroller.render();
            var b = this.scroller.el.addClass("fc-time-grid-container"),
                c = a('<div class="fc-time-grid" />').appendTo(b);
            this.el.find(".fc-body > tr > td").append(b), this.timeGrid.setElement(c), this.timeGrid.renderDates(), this.bottomRuleEl = a('<hr class="fc-divider ' + this.widgetHeaderClass + '"/>').appendTo(this.timeGrid.el), this.dayGrid && (this.dayGrid.setElement(this.el.find(".fc-day-grid")), this.dayGrid.renderDates(), this.dayGrid.bottomCoordPadding = this.dayGrid.el.next("hr").outerHeight()), this.noScrollRowEls = this.el.find(".fc-row:not(.fc-scroller *)")
        },
        renderHead: function () {
            this.headContainerEl = this.el.find(".fc-head-container").html(this.timeGrid.renderHeadHtml())
        },
        unrenderDates: function () {
            this.timeGrid.unrenderDates(), this.timeGrid.removeElement(), this.dayGrid && (this.dayGrid.unrenderDates(), this.dayGrid.removeElement()), this.scroller.destroy()
        },
        renderSkeletonHtml: function () {
            return '<table><thead class="fc-head"><tr><td class="fc-head-container ' + this.widgetHeaderClass + '"></td></tr></thead><tbody class="fc-body"><tr><td class="' + this.widgetContentClass + '">' + (this.dayGrid ? '<div class="fc-day-grid"/><hr class="fc-divider ' + this.widgetHeaderClass + '"/>' : "") + "</td></tr></tbody></table>"
        },
        axisStyleAttr: function () {
            return null !== this.axisWidth ? 'style="width:' + this.axisWidth + 'px"' : ""
        },
        renderBusinessHours: function () {
            this.timeGrid.renderBusinessHours(), this.dayGrid && this.dayGrid.renderBusinessHours()
        },
        unrenderBusinessHours: function () {
            this.timeGrid.unrenderBusinessHours(), this.dayGrid && this.dayGrid.unrenderBusinessHours()
        },
        getNowIndicatorUnit: function () {
            return this.timeGrid.getNowIndicatorUnit()
        },
        renderNowIndicator: function (a) {
            this.timeGrid.renderNowIndicator(a)
        },
        unrenderNowIndicator: function () {
            this.timeGrid.unrenderNowIndicator()
        },
        updateSize: function (a) {
            this.timeGrid.updateSize(a), xb.prototype.updateSize.call(this, a)
        },
        updateWidth: function () {
            this.axisWidth = k(this.el.find(".fc-axis"))
        },
        setHeight: function (a, b) {
            var c, d, g;
            this.bottomRuleEl.hide(), this.scroller.clear(), f(this.noScrollRowEls), this.dayGrid && (this.dayGrid.removeSegPopover(), c = this.opt("eventLimit"), c && "number" != typeof c && (c = Nb), c && this.dayGrid.limitRows(c)), b || (d = this.computeScrollerHeight(a), this.scroller.setHeight(d), g = this.scroller.getScrollbarWidths(), (g.left || g.right) && (e(this.noScrollRowEls, g), d = this.computeScrollerHeight(a), this.scroller.setHeight(d)), this.scroller.lockOverflow(g), this.timeGrid.getTotalSlatHeight() < d && this.bottomRuleEl.show())
        },
        computeScrollerHeight: function (a) {
            return a - l(this.el, this.scroller.el)
        },
        computeInitialScroll: function () {
            var a = b.duration(this.opt("scrollTime")),
                c = this.timeGrid.computeTimeTop(a);
            return c = Math.ceil(c), c && c++, c
        },
        queryScroll: function () {
            return this.scroller.getScrollTop()
        },
        setScroll: function (a) {
            this.scroller.setScrollTop(a)
        },
        prepareHits: function () {
            this.timeGrid.prepareHits(), this.dayGrid && this.dayGrid.prepareHits()
        },
        releaseHits: function () {
            this.timeGrid.releaseHits(), this.dayGrid && this.dayGrid.releaseHits()
        },
        queryHit: function (a, b) {
            var c = this.timeGrid.queryHit(a, b);
            return !c && this.dayGrid && (c = this.dayGrid.queryHit(a, b)), c
        },
        getHitSpan: function (a) {
            return a.component.getHitSpan(a)
        },
        getHitEl: function (a) {
            return a.component.getHitEl(a)
        },
        renderEvents: function (a) {
            var b, c, d = [],
                e = [],
                f = [];
            for (c = 0; c < a.length; c++) a[c].allDay ? d.push(a[c]) : e.push(a[c]);
            b = this.timeGrid.renderEvents(e), this.dayGrid && (f = this.dayGrid.renderEvents(d)), this.updateHeight()
        },
        getEventSegs: function () {
            return this.timeGrid.getEventSegs().concat(this.dayGrid ? this.dayGrid.getEventSegs() : [])
        },
        unrenderEvents: function () {
            this.timeGrid.unrenderEvents(), this.dayGrid && this.dayGrid.unrenderEvents()
        },
        renderDrag: function (a, b) {
            return a.start.hasTime() ? this.timeGrid.renderDrag(a, b) : this.dayGrid ? this.dayGrid.renderDrag(a, b) : void 0
        },
        unrenderDrag: function () {
            this.timeGrid.unrenderDrag(), this.dayGrid && this.dayGrid.unrenderDrag()
        },
        renderSelection: function (a) {
            a.start.hasTime() || a.end.hasTime() ? this.timeGrid.renderSelection(a) : this.dayGrid && this.dayGrid.renderSelection(a)
        },
        unrenderSelection: function () {
            this.timeGrid.unrenderSelection(), this.dayGrid && this.dayGrid.unrenderSelection()
        }
    }),
        Lb = {
            renderHeadIntroHtml: function () {
                var a, b = this.view;
                return b.opt("weekNumbers") ? (a = this.start.format(b.opt("smallWeekFormat")), '<th class="fc-axis fc-week-number ' + b.widgetHeaderClass + '" ' + b.axisStyleAttr() + "><span>" + ca(a) + "</span></th>") : '<th class="fc-axis ' + b.widgetHeaderClass + '" ' + b.axisStyleAttr() + "></th>"
            },
            renderBgIntroHtml: function () {
                var a = this.view;
                return '<td class="fc-axis ' + a.widgetContentClass + '" ' + a.axisStyleAttr() + "></td>"
            },
            renderIntroHtml: function () {
                var a = this.view;
                return '<td class="fc-axis" ' + a.axisStyleAttr() + "></td>"
            }
        },
        Mb = {
            renderBgIntroHtml: function () {
                var a = this.view;
                return '<td class="fc-axis ' + a.widgetContentClass + '" ' + a.axisStyleAttr() + "><span>" + (a.opt("allDayHtml") || ca(a.opt("allDayText"))) + "</span></td>"
            },
            renderIntroHtml: function () {
                var a = this.view;
                return '<td class="fc-axis" ' + a.axisStyleAttr() + "></td>"
            }
        },
        Nb = 5,
        Ob = [{
            hours: 1
        }, {
            minutes: 30
        }, {
            minutes: 15
        }, {
            seconds: 30
        }, {
            seconds: 15
        }];
    return Xa.agenda = {
        "class": Kb,
        defaults: {
            allDaySlot: !0,
            allDayText: "all-day",
            slotDuration: "00:30:00",
            minTime: "00:00:00",
            maxTime: "24:00:00",
            slotEventOverlap: !0
        }
    }, Xa.agendaDay = {
        type: "agenda",
        duration: {
            days: 1
        }
    }, Xa.agendaWeek = {
        type: "agenda",
        duration: {
            weeks: 1
        }
    }, Wa
});