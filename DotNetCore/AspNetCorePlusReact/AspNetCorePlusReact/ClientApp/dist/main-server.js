(function(e, a) { for(var i in a) e[i] = a[i]; }(exports, /******/ (function(modules) { // webpackBootstrap
/******/ 	// The module cache
/******/ 	var installedModules = {};
/******/
/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {
/******/
/******/ 		// Check if module is in cache
/******/ 		if(installedModules[moduleId]) {
/******/ 			return installedModules[moduleId].exports;
/******/ 		}
/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = installedModules[moduleId] = {
/******/ 			i: moduleId,
/******/ 			l: false,
/******/ 			exports: {}
/******/ 		};
/******/
/******/ 		// Execute the module function
/******/ 		modules[moduleId].call(module.exports, module, module.exports, __webpack_require__);
/******/
/******/ 		// Flag the module as loaded
/******/ 		module.l = true;
/******/
/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}
/******/
/******/
/******/ 	// expose the modules object (__webpack_modules__)
/******/ 	__webpack_require__.m = modules;
/******/
/******/ 	// expose the module cache
/******/ 	__webpack_require__.c = installedModules;
/******/
/******/ 	// identity function for calling harmony imports with the correct context
/******/ 	__webpack_require__.i = function(value) { return value; };
/******/
/******/ 	// define getter function for harmony exports
/******/ 	__webpack_require__.d = function(exports, name, getter) {
/******/ 		if(!__webpack_require__.o(exports, name)) {
/******/ 			Object.defineProperty(exports, name, {
/******/ 				configurable: false,
/******/ 				enumerable: true,
/******/ 				get: getter
/******/ 			});
/******/ 		}
/******/ 	};
/******/
/******/ 	// getDefaultExport function for compatibility with non-harmony modules
/******/ 	__webpack_require__.n = function(module) {
/******/ 		var getter = module && module.__esModule ?
/******/ 			function getDefault() { return module['default']; } :
/******/ 			function getModuleExports() { return module; };
/******/ 		__webpack_require__.d(getter, 'a', getter);
/******/ 		return getter;
/******/ 	};
/******/
/******/ 	// Object.prototype.hasOwnProperty.call
/******/ 	__webpack_require__.o = function(object, property) { return Object.prototype.hasOwnProperty.call(object, property); };
/******/
/******/ 	// __webpack_public_path__
/******/ 	__webpack_require__.p = "dist/";
/******/
/******/ 	// Load entry module and return exports
/******/ 	return __webpack_require__(__webpack_require__.s = 12);
/******/ })
/************************************************************************/
/******/ ([
/* 0 */
/***/ (function(module, exports) {

module.exports = require("./vendor");

/***/ }),
/* 1 */
/***/ (function(module, exports, __webpack_require__) {

module.exports = (__webpack_require__(0))(6);

/***/ }),
/* 2 */
/***/ (function(module, exports, __webpack_require__) {

module.exports = (__webpack_require__(0))(141);

/***/ }),
/* 3 */
/***/ (function(module, exports, __webpack_require__) {

module.exports = (__webpack_require__(0))(140);

/***/ }),
/* 4 */
/***/ (function(module, exports, __webpack_require__) {

module.exports = (__webpack_require__(0))(142);

/***/ }),
/* 5 */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return actionCreators; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "b", function() { return reducer; });
// ----------------
// ACTION CREATORS - These are functions exposed to UI components that will trigger a state transition.
// They don't directly mutate state, but they can have external side-effects (such as loading data).
var actionCreators = {
    increment: function () { return ({ type: 'INCREMENT_COUNT' }); },
    decrement: function () { return ({ type: 'DECREMENT_COUNT' }); }
};
// ----------------
// REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.
var reducer = function (state, action) {
    switch (action.type) {
        case 'INCREMENT_COUNT':
            return { count: state.count + 1 };
        case 'DECREMENT_COUNT':
            return { count: state.count - 1 };
        default:
            // The following line guarantees that every action in the KnownAction union has been covered by a case above
            var exhaustiveCheck = action;
    }
    // For unrecognized actions (or in cases where actions have no effect), must return the existing state
    //  (or default initial state if none was supplied)
    return state || { count: 0 };
};


/***/ }),
/* 6 */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return actionCreators; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "b", function() { return reducer; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_domain_task__ = __webpack_require__(19);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_domain_task___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0_domain_task__);

// ----------------
// ACTION CREATORS - These are functions exposed to UI components that will trigger a state transition.
// They don't directly mutate state, but they can have external side-effects (such as loading data).
var actionCreators = {
    requestWeatherForecasts: function (startDateIndex) { return function (dispatch, getState) {
        // Only load data if it's something we don't already have (and are not already loading)
        if (startDateIndex !== getState().weatherForecasts.startDateIndex) {
            var fetchTask = __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0_domain_task__["fetch"])("api/SampleData/WeatherForecasts?startDateIndex=" + startDateIndex)
                .then(function (response) { return response.json(); })
                .then(function (data) {
                dispatch({ type: 'RECEIVE_WEATHER_FORECASTS', startDateIndex: startDateIndex, forecasts: data });
            });
            __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0_domain_task__["addTask"])(fetchTask); // Ensure server-side prerendering waits for this to complete
            dispatch({ type: 'REQUEST_WEATHER_FORECASTS', startDateIndex: startDateIndex });
        }
    }; }
};
// ----------------
// REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.
var unloadedState = { forecasts: [], isLoading: false };
var reducer = function (state, incomingAction) {
    var action = incomingAction;
    switch (action.type) {
        case 'REQUEST_WEATHER_FORECASTS':
            return {
                startDateIndex: action.startDateIndex,
                forecasts: state.forecasts,
                isLoading: true
            };
        case 'RECEIVE_WEATHER_FORECASTS':
            // Only accept the incoming data if it matches the most recent request. This ensures we correctly
            // handle out-of-order responses.
            if (action.startDateIndex === state.startDateIndex) {
                return {
                    startDateIndex: action.startDateIndex,
                    forecasts: action.forecasts,
                    isLoading: false
                };
            }
            break;
        default:
            // The following line guarantees that every action in the KnownAction union has been covered by a case above
            var exhaustiveCheck = action;
    }
    return state || unloadedState;
};


/***/ }),
/* 7 */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (immutable) */ __webpack_exports__["a"] = configureStore;
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_redux__ = __webpack_require__(21);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_redux___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0_redux__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_redux_thunk__ = __webpack_require__(20);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_redux_thunk___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_1_redux_thunk__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2_react_router_redux__ = __webpack_require__(4);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2_react_router_redux___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_2_react_router_redux__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__store__ = __webpack_require__(18);




function configureStore(history, initialState) {
    // Build middleware. These are functions that can process the actions before they reach the store.
    var windowIfDefined = typeof window === 'undefined' ? null : window;
    // If devTools is installed, connect to it
    var devToolsExtension = windowIfDefined && windowIfDefined.__REDUX_DEVTOOLS_EXTENSION__;
    var createStoreWithMiddleware = __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0_redux__["compose"])(__webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0_redux__["applyMiddleware"])(__WEBPACK_IMPORTED_MODULE_1_redux_thunk___default.a, __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_2_react_router_redux__["routerMiddleware"])(history)), devToolsExtension ? devToolsExtension() : function (next) { return next; })(__WEBPACK_IMPORTED_MODULE_0_redux__["createStore"]);
    // Combine all reducers and instantiate the app-wide store instance
    var allReducers = buildRootReducer(__WEBPACK_IMPORTED_MODULE_3__store__["a" /* reducers */]);
    var store = createStoreWithMiddleware(allReducers, initialState);
    // Enable Webpack hot module replacement for reducers
    if (false) {
        module.hot.accept('./store', function () {
            var nextRootReducer = require('./store');
            store.replaceReducer(buildRootReducer(nextRootReducer.reducers));
        });
    }
    return store;
}
function buildRootReducer(allReducers) {
    return __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0_redux__["combineReducers"])(Object.assign({}, allReducers, { routing: __WEBPACK_IMPORTED_MODULE_2_react_router_redux__["routerReducer"] }));
}


/***/ }),
/* 8 */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return routes; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react__ = __webpack_require__(1);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0_react__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_react_router_dom__ = __webpack_require__(2);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_react_router_dom___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_1_react_router_dom__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__components_Layout__ = __webpack_require__(16);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__components_Home__ = __webpack_require__(15);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__components_FetchData__ = __webpack_require__(14);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__components_Counter__ = __webpack_require__(13);






var routes = __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_2__components_Layout__["a" /* Layout */], null,
    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_1_react_router_dom__["Route"], { exact: true, path: '/', component: __WEBPACK_IMPORTED_MODULE_3__components_Home__["a" /* default */] }),
    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_1_react_router_dom__["Route"], { path: '/counter', component: __WEBPACK_IMPORTED_MODULE_5__components_Counter__["a" /* default */] }),
    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_1_react_router_dom__["Route"], { path: '/fetchdata/:startDateIndex?', component: __WEBPACK_IMPORTED_MODULE_4__components_FetchData__["a" /* default */] }));


/***/ }),
/* 9 */
/***/ (function(module, exports, __webpack_require__) {

module.exports = (__webpack_require__(0))(132);

/***/ }),
/* 10 */
/***/ (function(module, exports, __webpack_require__) {

module.exports = (__webpack_require__(0))(137);

/***/ }),
/* 11 */
/***/ (function(module, exports, __webpack_require__) {

module.exports = (__webpack_require__(0))(139);

/***/ }),
/* 12 */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react__ = __webpack_require__(1);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0_react__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_react_redux__ = __webpack_require__(3);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_react_redux___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_1_react_redux__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2_react_dom_server__ = __webpack_require__(11);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2_react_dom_server___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_2_react_dom_server__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3_react_router_dom__ = __webpack_require__(2);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3_react_router_dom___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_3_react_router_dom__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4_react_router_redux__ = __webpack_require__(4);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4_react_router_redux___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_4_react_router_redux__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5_history__ = __webpack_require__(10);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5_history___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_5_history__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6_aspnet_prerendering__ = __webpack_require__(9);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6_aspnet_prerendering___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_6_aspnet_prerendering__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_7__routes__ = __webpack_require__(8);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_8__configureStore__ = __webpack_require__(7);









/* harmony default export */ __webpack_exports__["default"] = (__webpack_require__.i(__WEBPACK_IMPORTED_MODULE_6_aspnet_prerendering__["createServerRenderer"])(function (params) {
    return new Promise(function (resolve, reject) {
        // Prepare Redux store with in-memory history, and dispatch a navigation event
        // corresponding to the incoming URL
        var basename = params.baseUrl.substring(0, params.baseUrl.length - 1); // Remove trailing slash
        var urlAfterBasename = params.url.substring(basename.length);
        var store = __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_8__configureStore__["a" /* default */])(__webpack_require__.i(__WEBPACK_IMPORTED_MODULE_5_history__["createMemoryHistory"])());
        store.dispatch(__webpack_require__.i(__WEBPACK_IMPORTED_MODULE_4_react_router_redux__["replace"])(urlAfterBasename));
        // Prepare an instance of the application and perform an inital render that will
        // cause any async tasks (e.g., data access) to begin
        var routerContext = {};
        var app = (__WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_1_react_redux__["Provider"], { store: store },
            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_3_react_router_dom__["StaticRouter"], { basename: basename, context: routerContext, location: params.location.path, children: __WEBPACK_IMPORTED_MODULE_7__routes__["a" /* routes */] })));
        __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_2_react_dom_server__["renderToString"])(app);
        // If there's a redirection, just send this information back to the host application
        if (routerContext.url) {
            resolve({ redirectUrl: routerContext.url });
            return;
        }
        // Once any async tasks are done, we can perform the final render
        // We also send the redux store state, so the client can continue execution where the server left off
        params.domainTasks.then(function () {
            resolve({
                html: __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_2_react_dom_server__["renderToString"])(app),
                globals: { initialReduxState: store.getState() }
            });
        }, reject); // Also propagate any errors back into the host application
    });
}));


/***/ }),
/* 13 */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react__ = __webpack_require__(1);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0_react__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_react_redux__ = __webpack_require__(3);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_react_redux___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_1_react_redux__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__store_Counter__ = __webpack_require__(5);
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();



var Counter = (function (_super) {
    __extends(Counter, _super);
    function Counter() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    Counter.prototype.render = function () {
        var _this = this;
        return __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", null,
            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("h1", null, "Counter"),
            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("p", null, "This is a simple example of a React component."),
            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("p", null,
                "Current count: ",
                __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("strong", null, this.props.count)),
            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("button", { onClick: function () { _this.props.increment(); } }, "Increment"));
    };
    return Counter;
}(__WEBPACK_IMPORTED_MODULE_0_react__["Component"]));
// Wire up the React component to the Redux store
/* harmony default export */ __webpack_exports__["a"] = (__webpack_require__.i(__WEBPACK_IMPORTED_MODULE_1_react_redux__["connect"])(function (state) { return state.counter; }, // Selects which state properties are merged into the component's props
__WEBPACK_IMPORTED_MODULE_2__store_Counter__["a" /* actionCreators */] // Selects which action creators are merged into the component's props
)(Counter));


/***/ }),
/* 14 */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react__ = __webpack_require__(1);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0_react__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_react_router_dom__ = __webpack_require__(2);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_react_router_dom___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_1_react_router_dom__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2_react_redux__ = __webpack_require__(3);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2_react_redux___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_2_react_redux__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__store_WeatherForecasts__ = __webpack_require__(6);
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();




var FetchData = (function (_super) {
    __extends(FetchData, _super);
    function FetchData() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    FetchData.prototype.componentWillMount = function () {
        // This method runs when the component is first added to the page
        var startDateIndex = parseInt(this.props.match.params.startDateIndex) || 0;
        this.props.requestWeatherForecasts(startDateIndex);
    };
    FetchData.prototype.componentWillReceiveProps = function (nextProps) {
        // This method runs when incoming props (e.g., route params) change
        var startDateIndex = parseInt(nextProps.match.params.startDateIndex) || 0;
        this.props.requestWeatherForecasts(startDateIndex);
    };
    FetchData.prototype.render = function () {
        return __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", null,
            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("h1", null, "Weather forecast"),
            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("p", null, "This component demonstrates fetching data from the server and working with URL parameters."),
            this.renderForecastsTable(),
            this.renderPagination());
    };
    FetchData.prototype.renderForecastsTable = function () {
        return __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("table", { className: 'table' },
            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("thead", null,
                __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("tr", null,
                    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("th", null, "Date"),
                    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("th", null, "Temp. (C)"),
                    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("th", null, "Temp. (F)"),
                    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("th", null, "Summary"))),
            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("tbody", null, this.props.forecasts.map(function (forecast) {
                return __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("tr", { key: forecast.dateFormatted },
                    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("td", null, forecast.dateFormatted),
                    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("td", null, forecast.temperatureC),
                    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("td", null, forecast.temperatureF),
                    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("td", null, forecast.summary));
            })));
    };
    FetchData.prototype.renderPagination = function () {
        var prevStartDateIndex = (this.props.startDateIndex || 0) - 5;
        var nextStartDateIndex = (this.props.startDateIndex || 0) + 5;
        return __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("p", { className: 'clearfix text-center' },
            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_1_react_router_dom__["Link"], { className: 'btn btn-default pull-left', to: "/fetchdata/" + prevStartDateIndex }, "Previous"),
            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_1_react_router_dom__["Link"], { className: 'btn btn-default pull-right', to: "/fetchdata/" + nextStartDateIndex }, "Next"),
            this.props.isLoading ? __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("span", null, "Loading...") : []);
    };
    return FetchData;
}(__WEBPACK_IMPORTED_MODULE_0_react__["Component"]));
/* harmony default export */ __webpack_exports__["a"] = (__webpack_require__.i(__WEBPACK_IMPORTED_MODULE_2_react_redux__["connect"])(function (state) { return state.weatherForecasts; }, // Selects which state properties are merged into the component's props
__WEBPACK_IMPORTED_MODULE_3__store_WeatherForecasts__["a" /* actionCreators */] // Selects which action creators are merged into the component's props
)(FetchData));


/***/ }),
/* 15 */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react__ = __webpack_require__(1);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0_react__);
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();

var Home = (function (_super) {
    __extends(Home, _super);
    function Home() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    Home.prototype.render = function () {
        return __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", null,
            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("h1", null, "Hello, world!"),
            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("p", null, "Welcome to your new single-page application, built with:"),
            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("ul", null,
                __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("li", null,
                    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("a", { href: 'https://get.asp.net/' }, "ASP.NET Core"),
                    " and ",
                    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("a", { href: 'https://msdn.microsoft.com/en-us/library/67ef8sbd.aspx' }, "C#"),
                    " for cross-platform server-side code"),
                __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("li", null,
                    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("a", { href: 'https://facebook.github.io/react/' }, "React"),
                    ", ",
                    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("a", { href: 'http://redux.js.org' }, "Redux"),
                    ", and ",
                    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("a", { href: 'http://www.typescriptlang.org/' }, "TypeScript"),
                    " for client-side code"),
                __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("li", null,
                    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("a", { href: 'https://webpack.github.io/' }, "Webpack"),
                    " for building and bundling client-side resources"),
                __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("li", null,
                    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("a", { href: 'http://getbootstrap.com/' }, "Bootstrap"),
                    " for layout and styling")),
            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("p", null, "To help you get started, we've also set up:"),
            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("ul", null,
                __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("li", null,
                    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("strong", null, "Client-side navigation"),
                    ". For example, click ",
                    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("em", null, "Counter"),
                    " then ",
                    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("em", null, "Back"),
                    " to return here."),
                __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("li", null,
                    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("strong", null, "Webpack dev middleware"),
                    ". In development mode, there's no need to run the ",
                    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("code", null, "webpack"),
                    " build tool. Your client-side resources are dynamically built on demand. Updates are available as soon as you modify any file."),
                __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("li", null,
                    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("strong", null, "Hot module replacement"),
                    ". In development mode, you don't even need to reload the page after making most changes. Within seconds of saving changes to files, rebuilt React components will be injected directly into your running application, preserving its live state."),
                __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("li", null,
                    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("strong", null, "Efficient production builds"),
                    ". In production mode, development-time features are disabled, and the ",
                    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("code", null, "webpack"),
                    " build tool produces minified static CSS and JavaScript files."),
                __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("li", null,
                    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("strong", null, "Server-side prerendering"),
                    ". To optimize startup time, your React application is first rendered on the server. The initial HTML and state is then transferred to the browser, where client-side code picks up where the server left off.")));
    };
    return Home;
}(__WEBPACK_IMPORTED_MODULE_0_react__["Component"]));
/* harmony default export */ __webpack_exports__["a"] = (Home);


/***/ }),
/* 16 */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return Layout; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react__ = __webpack_require__(1);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0_react__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__NavMenu__ = __webpack_require__(17);
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();


var Layout = (function (_super) {
    __extends(Layout, _super);
    function Layout() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    Layout.prototype.render = function () {
        return __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", { className: 'container-fluid' },
            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", { className: 'row' },
                __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", { className: 'col-sm-3' },
                    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_1__NavMenu__["a" /* NavMenu */], null)),
                __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", { className: 'col-sm-9' }, this.props.children)));
    };
    return Layout;
}(__WEBPACK_IMPORTED_MODULE_0_react__["Component"]));



/***/ }),
/* 17 */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return NavMenu; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react__ = __webpack_require__(1);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0_react__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_react_router_dom__ = __webpack_require__(2);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_react_router_dom___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_1_react_router_dom__);
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();


var NavMenu = (function (_super) {
    __extends(NavMenu, _super);
    function NavMenu() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    NavMenu.prototype.render = function () {
        return __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", { className: 'main-nav' },
            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", { className: 'navbar navbar-inverse' },
                __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", { className: 'navbar-header' },
                    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("button", { type: 'button', className: 'navbar-toggle', "data-toggle": 'collapse', "data-target": '.navbar-collapse' },
                        __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("span", { className: 'sr-only' }, "Toggle navigation"),
                        __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("span", { className: 'icon-bar' }),
                        __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("span", { className: 'icon-bar' }),
                        __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("span", { className: 'icon-bar' })),
                    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_1_react_router_dom__["Link"], { className: 'navbar-brand', to: '/' }, "AspNetCorePlusReact")),
                __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", { className: 'clearfix' }),
                __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", { className: 'navbar-collapse collapse' },
                    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("ul", { className: 'nav navbar-nav' },
                        __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("li", null,
                            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_1_react_router_dom__["NavLink"], { exact: true, to: '/', activeClassName: 'active' },
                                __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("span", { className: 'glyphicon glyphicon-home' }),
                                " Home")),
                        __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("li", null,
                            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_1_react_router_dom__["NavLink"], { to: '/counter', activeClassName: 'active' },
                                __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("span", { className: 'glyphicon glyphicon-education' }),
                                " Counter")),
                        __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("li", null,
                            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_1_react_router_dom__["NavLink"], { to: '/fetchdata', activeClassName: 'active' },
                                __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("span", { className: 'glyphicon glyphicon-th-list' }),
                                " Fetch data"))))));
    };
    return NavMenu;
}(__WEBPACK_IMPORTED_MODULE_0_react__["Component"]));



/***/ }),
/* 18 */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return reducers; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__WeatherForecasts__ = __webpack_require__(6);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__Counter__ = __webpack_require__(5);


// Whenever an action is dispatched, Redux will update each top-level application state property using
// the reducer with the matching name. It's important that the names match exactly, and that the reducer
// acts on the corresponding ApplicationState property type.
var reducers = {
    counter: __WEBPACK_IMPORTED_MODULE_1__Counter__["b" /* reducer */],
    weatherForecasts: __WEBPACK_IMPORTED_MODULE_0__WeatherForecasts__["b" /* reducer */]
};


/***/ }),
/* 19 */
/***/ (function(module, exports, __webpack_require__) {

module.exports = (__webpack_require__(0))(135);

/***/ }),
/* 20 */
/***/ (function(module, exports, __webpack_require__) {

module.exports = (__webpack_require__(0))(143);

/***/ }),
/* 21 */
/***/ (function(module, exports, __webpack_require__) {

module.exports = (__webpack_require__(0))(70);

/***/ })
/******/ ])));
//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbIndlYnBhY2s6Ly8vd2VicGFjay9ib290c3RyYXAgNmJjNTRiMGVjYzI5M2YwYjM1NzgiLCJ3ZWJwYWNrOi8vL2V4dGVybmFsIFwiLi92ZW5kb3JcIiIsIndlYnBhY2s6Ly8vZGVsZWdhdGVkIC4vbm9kZV9tb2R1bGVzL3JlYWN0L3JlYWN0LmpzIGZyb20gZGxsLXJlZmVyZW5jZSAuL3ZlbmRvciIsIndlYnBhY2s6Ly8vZGVsZWdhdGVkIC4vbm9kZV9tb2R1bGVzL3JlYWN0LXJvdXRlci1kb20vaW5kZXguanMgZnJvbSBkbGwtcmVmZXJlbmNlIC4vdmVuZG9yIiwid2VicGFjazovLy9kZWxlZ2F0ZWQgLi9ub2RlX21vZHVsZXMvcmVhY3QtcmVkdXgvbGliL2luZGV4LmpzIGZyb20gZGxsLXJlZmVyZW5jZSAuL3ZlbmRvciIsIndlYnBhY2s6Ly8vZGVsZWdhdGVkIC4vbm9kZV9tb2R1bGVzL3JlYWN0LXJvdXRlci1yZWR1eC9pbmRleC5qcyBmcm9tIGRsbC1yZWZlcmVuY2UgLi92ZW5kb3IiLCJ3ZWJwYWNrOi8vLy4vQ2xpZW50QXBwL3N0b3JlL0NvdW50ZXIudHMiLCJ3ZWJwYWNrOi8vLy4vQ2xpZW50QXBwL3N0b3JlL1dlYXRoZXJGb3JlY2FzdHMudHMiLCJ3ZWJwYWNrOi8vLy4vQ2xpZW50QXBwL2NvbmZpZ3VyZVN0b3JlLnRzIiwid2VicGFjazovLy8uL0NsaWVudEFwcC9yb3V0ZXMudHN4Iiwid2VicGFjazovLy9kZWxlZ2F0ZWQgLi9ub2RlX21vZHVsZXMvYXNwbmV0LXByZXJlbmRlcmluZy9pbmRleC5qcyBmcm9tIGRsbC1yZWZlcmVuY2UgLi92ZW5kb3IiLCJ3ZWJwYWNrOi8vL2RlbGVnYXRlZCAuL25vZGVfbW9kdWxlcy9oaXN0b3J5L2luZGV4LmpzIGZyb20gZGxsLXJlZmVyZW5jZSAuL3ZlbmRvciIsIndlYnBhY2s6Ly8vZGVsZWdhdGVkIC4vbm9kZV9tb2R1bGVzL3JlYWN0LWRvbS9zZXJ2ZXIuanMgZnJvbSBkbGwtcmVmZXJlbmNlIC4vdmVuZG9yIiwid2VicGFjazovLy8uL0NsaWVudEFwcC9ib290LXNlcnZlci50c3giLCJ3ZWJwYWNrOi8vLy4vQ2xpZW50QXBwL2NvbXBvbmVudHMvQ291bnRlci50c3giLCJ3ZWJwYWNrOi8vLy4vQ2xpZW50QXBwL2NvbXBvbmVudHMvRmV0Y2hEYXRhLnRzeCIsIndlYnBhY2s6Ly8vLi9DbGllbnRBcHAvY29tcG9uZW50cy9Ib21lLnRzeCIsIndlYnBhY2s6Ly8vLi9DbGllbnRBcHAvY29tcG9uZW50cy9MYXlvdXQudHN4Iiwid2VicGFjazovLy8uL0NsaWVudEFwcC9jb21wb25lbnRzL05hdk1lbnUudHN4Iiwid2VicGFjazovLy8uL0NsaWVudEFwcC9zdG9yZS9pbmRleC50cyIsIndlYnBhY2s6Ly8vZGVsZWdhdGVkIC4vbm9kZV9tb2R1bGVzL2RvbWFpbi10YXNrL2luZGV4LmpzIGZyb20gZGxsLXJlZmVyZW5jZSAuL3ZlbmRvciIsIndlYnBhY2s6Ly8vZGVsZWdhdGVkIC4vbm9kZV9tb2R1bGVzL3JlZHV4LXRodW5rL2xpYi9pbmRleC5qcyBmcm9tIGRsbC1yZWZlcmVuY2UgLi92ZW5kb3IiLCJ3ZWJwYWNrOi8vL2RlbGVnYXRlZCAuL25vZGVfbW9kdWxlcy9yZWR1eC9saWIvaW5kZXguanMgZnJvbSBkbGwtcmVmZXJlbmNlIC4vdmVuZG9yIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiI7QUFBQTtBQUNBOztBQUVBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTs7QUFFQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTs7O0FBR0E7QUFDQTs7QUFFQTtBQUNBOztBQUVBO0FBQ0EsbURBQTJDLGNBQWM7O0FBRXpEO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0EsYUFBSztBQUNMO0FBQ0E7O0FBRUE7QUFDQTtBQUNBO0FBQ0EsbUNBQTJCLDBCQUEwQixFQUFFO0FBQ3ZELHlDQUFpQyxlQUFlO0FBQ2hEO0FBQ0E7QUFDQTs7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UyxFQUFDLFVBQVUsR0FBUSxDQUM3QjtvQkFDVCxxREFBQyxzREFBSSxJQUFDLFNBQVMsRUFBQyxjQUFjLEVBQUMsRUFBRSxFQUFHLEdBQUcsMEJBQTZCLENBQ2xFO2dCQUNOLDhEQUFLLFNBQVMsRUFBQyxVQUFVLEdBQU87Z0JBQ2hDLDhEQUFLLFNBQVMsRUFBQywwQkFBMEI7b0JBQ3JDLDZEQUFJLFNBQVMsRUFBQyxnQkFBZ0I7d0JBQzFCOzRCQUNJLHFEQUFDLHlEQUFPLElBQUMsS0FBSyxRQUFDLEVBQUUsRUFBRyxHQUFHLEVBQUcsZUFBZSxFQUFDLFFBQVE7Z0NBQzlDLCtEQUFNLFNBQVMsRUFBQywwQkFBMEIsR0FBUTt3Q0FDNUMsQ0FDVDt3QkFDTDs0QkFDSSxxREFBQyx5REFBTyxJQUFDLEVBQUUsRUFBRyxVQUFVLEVBQUcsZUFBZSxFQUFDLFFBQVE7Z0NBQy9DLCtEQUFNLFNBQVMsRUFBQywrQkFBK0IsR0FBUTsyQ0FDakQsQ0FDVDt3QkFDTDs0QkFDSSxxREFBQyx5REFBTyxJQUFDLEVBQUUsRUFBRyxZQUFZLEVBQUcsZUFBZSxFQUFDLFFBQVE7Z0NBQ2pELCtEQUFNLFNBQVMsRUFBQyw2QkFBNkIsR0FBUTs4Q0FDL0MsQ0FDVCxDQUNKLENBQ0gsQ0FDSixDQUNKLENBQUM7SUFDWCxDQUFDO0lBQ0wsY0FBQztBQUFELENBQUMsQ0FwQzRCLGdEQUFlLEdBb0MzQzs7Ozs7Ozs7Ozs7O0FDdkNzRDtBQUNsQjtBQVFyQyxzR0FBc0c7QUFDdEcsd0dBQXdHO0FBQ3hHLDREQUE0RDtBQUNyRCxJQUFNLFFBQVEsR0FBRztJQUNwQixPQUFPLEVBQUUseURBQWU7SUFDeEIsZ0JBQWdCLEVBQUUsa0VBQXdCO0NBQzdDLENBQUM7Ozs7Ozs7QUNmRiwrQzs7Ozs7O0FDQUEsK0M7Ozs7OztBQ0FBLDhDIiwiZmlsZSI6Im1haW4tc2VydmVyLmpzIiwic291cmNlc0NvbnRlbnQiOlsiIFx0Ly8gVGhlIG1vZHVsZSBjYWNoZVxuIFx0dmFyIGluc3RhbGxlZE1vZHVsZXMgPSB7fTtcblxuIFx0Ly8gVGhlIHJlcXVpcmUgZnVuY3Rpb25cbiBcdGZ1bmN0aW9uIF9fd2VicGFja19yZXF1aXJlX18obW9kdWxlSWQpIHtcblxuIFx0XHQvLyBDaGVjayBpZiBtb2R1bGUgaXMgaW4gY2FjaGVcbiBcdFx0aWYoaW5zdGFsbGVkTW9kdWxlc1ttb2R1bGVJZF0pIHtcbiBcdFx0XHRyZXR1cm4gaW5zdGFsbGVkTW9kdWxlc1ttb2R1bGVJZF0uZXhwb3J0cztcbiBcdFx0fVxuIFx0XHQvLyBDcmVhdGUgYSBuZXcgbW9kdWxlIChhbmQgcHV0IGl0IGludG8gdGhlIGNhY2hlKVxuIFx0XHR2YXIgbW9kdWxlID0gaW5zdGFsbGVkTW9kdWxlc1ttb2R1bGVJZF0gPSB7XG4gXHRcdFx0aTogbW9kdWxlSWQsXG4gXHRcdFx0bDogZmFsc2UsXG4gXHRcdFx0ZXhwb3J0czoge31cbiBcdFx0fTtcblxuIFx0XHQvLyBFeGVjdXRlIHRoZSBtb2R1bGUgZnVuY3Rpb25cbiBcdFx0bW9kdWxlc1ttb2R1bGVJZF0uY2FsbChtb2R1bGUuZXhwb3J0cywgbW9kdWxlLCBtb2R1bGUuZXhwb3J0cywgX193ZWJwYWNrX3JlcXVpcmVfXyk7XG5cbiBcdFx0Ly8gRmxhZyB0aGUgbW9kdWxlIGFzIGxvYWRlZFxuIFx0XHRtb2R1bGUubCA9IHRydWU7XG5cbiBcdFx0Ly8gUmV0dXJuIHRoZSBleHBvcnRzIG9mIHRoZSBtb2R1bGVcbiBcdFx0cmV0dXJuIG1vZHVsZS5leHBvcnRzO1xuIFx0fVxuXG5cbiBcdC8vIGV4cG9zZSB0aGUgbW9kdWxlcyBvYmplY3QgKF9fd2VicGFja19tb2R1bGVzX18pXG4gXHRfX3dlYnBhY2tfcmVxdWlyZV9fLm0gPSBtb2R1bGVzO1xuXG4gXHQvLyBleHBvc2UgdGhlIG1vZHVsZSBjYWNoZVxuIFx0X193ZWJwYWNrX3JlcXVpcmVfXy5jID0gaW5zdGFsbGVkTW9kdWxlcztcblxuIFx0Ly8gaWRlbnRpdHkgZnVuY3Rpb24gZm9yIGNhbGxpbmcgaGFybW9ueSBpbXBvcnRzIHdpdGggdGhlIGNvcnJlY3QgY29udGV4dFxuIFx0X193ZWJwYWNrX3JlcXVpcmVfXy5pID0gZnVuY3Rpb24odmFsdWUpIHsgcmV0dXJuIHZhbHVlOyB9O1xuXG4gXHQvLyBkZWZpbmUgZ2V0dGVyIGZ1bmN0aW9uIGZvciBoYXJtb255IGV4cG9ydHNcbiBcdF9fd2VicGFja19yZXF1aXJlX18uZCA9IGZ1bmN0aW9uKGV4cG9ydHMsIG5hbWUsIGdldHRlcikge1xuIFx0XHRpZighX193ZWJwYWNrX3JlcXVpcmVfXy5vKGV4cG9ydHMsIG5hbWUpKSB7XG4gXHRcdFx0T2JqZWN0LmRlZmluZVByb3BlcnR5KGV4cG9ydHMsIG5hbWUsIHtcbiBcdFx0XHRcdGNvbmZpZ3VyYWJsZTogZmFsc2UsXG4gXHRcdFx0XHRlbnVtZXJhYmxlOiB0cnVlLFxuIFx0XHRcdFx0Z2V0OiBnZXR0ZXJcbiBcdFx0XHR9KTtcbiBcdFx0fVxuIFx0fTtcblxuIFx0Ly8gZ2V0RGVmYXVsdEV4cG9ydCBmdW5jdGlvbiBmb3IgY29tcGF0aWJpbGl0eSB3aXRoIG5vbi1oYXJtb255IG1vZHVsZXNcbiBcdF9fd2VicGFja19yZXF1aXJlX18ubiA9IGZ1bmN0aW9uKG1vZHVsZSkge1xuIFx0XHR2YXIgZ2V0dGVyID0gbW9kdWxlICYmIG1vZHVsZS5fX2VzTW9kdWxlID9cbiBcdFx0XHRmdW5jdGlvbiBnZXREZWZhdWx0KCkgeyByZXR1cm4gbW9kdWxlWydkZWZhdWx0J107IH0gOlxuIFx0XHRcdGZ1bmN0aW9uIGdldE1vZHVsZUV4cG9ydHMoKSB7IHJldHVybiBtb2R1bGU7IH07XG4gXHRcdF9fd2VicGFja19yZXF1aXJlX18uZChnZXR0ZXIsICdhJywgZ2V0dGVyKTtcbiBcdFx0cmV0dXJuIGdldHRlcjtcbiBcdH07XG5cbiBcdC8vIE9iamVjdC5wcm90b3R5cGUuaGFzT3duUHJvcGVydHkuY2FsbFxuIFx0X193ZWJwYWNrX3JlcXVpcmVfXy5vID0gZnVuY3Rpb24ob2JqZWN0LCBwcm9wZXJ0eSkgeyByZXR1cm4gT2JqZWN0LnByb3RvdHlwZS5oYXNPd25Qcm9wZXJ0eS5jYWxsKG9iamVjdCwgcHJvcGVydHkpOyB9O1xuXG4gXHQvLyBfX3dlYnBhY2tfcHVibGljX3BhdGhfX1xuIFx0X193ZWJwYWNrX3JlcXVpcmVfXy5wID0gXCJkaXN0L1wiO1xuXG4gXHQvLyBMb2FkIGVudHJ5IG1vZHVsZSBhbmQgcmV0dXJuIGV4cG9ydHNcbiBcdHJldHVybiBfX3dlYnBhY2tfcmVxdWlyZV9fKF9fd2VicGFja19yZXF1aXJlX18ucyA9IDEyKTtcblxuXG5cbi8vIFdFQlBBQ0sgRk9PVEVSIC8vXG4vLyB3ZWJwYWNrL2Jvb3RzdHJhcCA2YmM1NGIwZWNjMjkzZjBiMzU3OCIsIm1vZHVsZS5leHBvcnRzID0gcmVxdWlyZShcIi4vdmVuZG9yXCIpO1xuXG5cbi8vLy8vLy8vLy8vLy8vLy8vL1xuLy8gV0VCUEFDSyBGT09URVJcbi8vIGV4dGVybmFsIFwiLi92ZW5kb3JcIlxuLy8gbW9kdWxlIGlkID0gMFxuLy8gbW9kdWxlIGNodW5rcyA9IDAiLCJtb2R1bGUuZXhwb3J0cyA9IChfX3dlYnBhY2tfcmVxdWlyZV9fKDApKSg2KTtcblxuXG4vLy8vLy8vLy8vLy8vLy8vLy9cbi8vIFdFQlBBQ0sgRk9PVEVSXG4vLyBkZWxlZ2F0ZWQgLi9ub2RlX21vZHVsZXMvcmVhY3QvcmVhY3QuanMgZnJvbSBkbGwtcmVmZXJlbmNlIC4vdmVuZG9yXG4vLyBtb2R1bGUgaWQgPSAxXG4vLyBtb2R1bGUgY2h1bmtzID0gMCIsIm1vZHVsZS5leHBvcnRzID0gKF9fd2VicGFja19yZXF1aXJlX18oMCkpKDE0MSk7XG5cblxuLy8vLy8vLy8vLy8vLy8vLy8vXG4vLyBXRUJQQUNLIEZPT1RFUlxuLy8gZGVsZWdhdGVkIC4vbm9kZV9tb2R1bGVzL3JlYWN0LXJvdXRlci1kb20vaW5kZXguanMgZnJvbSBkbGwtcmVmZXJlbmNlIC4vdmVuZG9yXG4vLyBtb2R1bGUgaWQgPSAyXG4vLyBtb2R1bGUgY2h1bmtzID0gMCIsIm1vZHVsZS5leHBvcnRzID0gKF9fd2VicGFja19yZXF1aXJlX18oMCkpKDE0MCk7XG5cblxuLy8vLy8vLy8vLy8vLy8vLy8vXG4vLyBXRUJQQUNLIEZPT1RFUlxuLy8gZGVsZWdhdGVkIC4vbm9kZV9tb2R1bGVzL3JlYWN0LXJlZHV4L2xpYi9pbmRleC5qcyBmcm9tIGRsbC1yZWZlcmVuY2UgLi92ZW5kb3Jcbi8vIG1vZHVsZSBpZCA9IDNcbi8vIG1vZHVsZSBjaHVua3MgPSAwIiwibW9kdWxlLmV4cG9ydHMgPSAoX193ZWJwYWNrX3JlcXVpcmVfXygwKSkoMTQyKTtcblxuXG4vLy8vLy8vLy8vLy8vLy8vLy9cbi8vIFdFQlBBQ0sgRk9PVEVSXG4vLyBkZWxlZ2F0ZWQgLi9ub2RlX21vZHVsZXMvcmVhY3Qtcm91dGVyLXJlZHV4L2luZGV4LmpzIGZyb20gZGxsLXJlZmVyZW5jZSAuL3ZlbmRvclxuLy8gbW9kdWxlIGlkID0gNFxuLy8gbW9kdWxlIGNodW5rcyA9IDAiLCJpbXBvcnQgeyBBY3Rpb24sIFJlZHVjZXIgfSBmcm9tICdyZWR1eCc7XHJcblxyXG4vLyAtLS0tLS0tLS0tLS0tLS0tLVxyXG4vLyBTVEFURSAtIFRoaXMgZGVmaW5lcyB0aGUgdHlwZSBvZiBkYXRhIG1haW50YWluZWQgaW4gdGhlIFJlZHV4IHN0b3JlLlxyXG5cclxuZXhwb3J0IGludGVyZmFjZSBDb3VudGVyU3RhdGUge1xyXG4gICAgY291bnQ6IG51bWJlcjtcclxufVxyXG5cclxuLy8gLS0tLS0tLS0tLS0tLS0tLS1cclxuLy8gQUNUSU9OUyAtIFRoZXNlIGFyZSBzZXJpYWxpemFibGUgKGhlbmNlIHJlcGxheWFibGUpIGRlc2NyaXB0aW9ucyBvZiBzdGF0ZSB0cmFuc2l0aW9ucy5cclxuLy8gVGhleSBkbyBub3QgdGhlbXNlbHZlcyBoYXZlIGFueSBzaWRlLWVmZmVjdHM7IHRoZXkganVzdCBkZXNjcmliZSBzb21ldGhpbmcgdGhhdCBpcyBnb2luZyB0byBoYXBwZW4uXHJcbi8vIFVzZSBAdHlwZU5hbWUgYW5kIGlzQWN0aW9uVHlwZSBmb3IgdHlwZSBkZXRlY3Rpb24gdGhhdCB3b3JrcyBldmVuIGFmdGVyIHNlcmlhbGl6YXRpb24vZGVzZXJpYWxpemF0aW9uLlxyXG5cclxuaW50ZXJmYWNlIEluY3JlbWVudENvdW50QWN0aW9uIHsgdHlwZTogJ0lOQ1JFTUVOVF9DT1VOVCcgfVxyXG5pbnRlcmZhY2UgRGVjcmVtZW50Q291bnRBY3Rpb24geyB0eXBlOiAnREVDUkVNRU5UX0NPVU5UJyB9XHJcblxyXG4vLyBEZWNsYXJlIGEgJ2Rpc2NyaW1pbmF0ZWQgdW5pb24nIHR5cGUuIFRoaXMgZ3VhcmFudGVlcyB0aGF0IGFsbCByZWZlcmVuY2VzIHRvICd0eXBlJyBwcm9wZXJ0aWVzIGNvbnRhaW4gb25lIG9mIHRoZVxyXG4vLyBkZWNsYXJlZCB0eXBlIHN0cmluZ3MgKGFuZCBub3QgYW55IG90aGVyIGFyYml0cmFyeSBzdHJpbmcpLlxyXG50eXBlIEtub3duQWN0aW9uID0gSW5jcmVtZW50Q291bnRBY3Rpb24gfCBEZWNyZW1lbnRDb3VudEFjdGlvbjtcclxuXHJcbi8vIC0tLS0tLS0tLS0tLS0tLS1cclxuLy8gQUNUSU9OIENSRUFUT1JTIC0gVGhlc2UgYXJlIGZ1bmN0aW9ucyBleHBvc2VkIHRvIFVJIGNvbXBvbmVudHMgdGhhdCB3aWxsIHRyaWdnZXIgYSBzdGF0ZSB0cmFuc2l0aW9uLlxyXG4vLyBUaGV5IGRvbid0IGRpcmVjdGx5IG11dGF0ZSBzdGF0ZSwgYnV0IHRoZXkgY2FuIGhhdmUgZXh0ZXJuYWwgc2lkZS1lZmZlY3RzIChzdWNoIGFzIGxvYWRpbmcgZGF0YSkuXHJcblxyXG5leHBvcnQgY29uc3QgYWN0aW9uQ3JlYXRvcnMgPSB7XHJcbiAgICBpbmNyZW1lbnQ6ICgpID0+IDxJbmNyZW1lbnRDb3VudEFjdGlvbj57IHR5cGU6ICdJTkNSRU1FTlRfQ09VTlQnIH0sXHJcbiAgICBkZWNyZW1lbnQ6ICgpID0+IDxEZWNyZW1lbnRDb3VudEFjdGlvbj57IHR5cGU6ICdERUNSRU1FTlRfQ09VTlQnIH1cclxufTtcclxuXHJcbi8vIC0tLS0tLS0tLS0tLS0tLS1cclxuLy8gUkVEVUNFUiAtIEZvciBhIGdpdmVuIHN0YXRlIGFuZCBhY3Rpb24sIHJldHVybnMgdGhlIG5ldyBzdGF0ZS4gVG8gc3VwcG9ydCB0aW1lIHRyYXZlbCwgdGhpcyBtdXN0IG5vdCBtdXRhdGUgdGhlIG9sZCBzdGF0ZS5cclxuXHJcbmV4cG9ydCBjb25zdCByZWR1Y2VyOiBSZWR1Y2VyPENvdW50ZXJTdGF0ZT4gPSAoc3RhdGU6IENvdW50ZXJTdGF0ZSwgYWN0aW9uOiBLbm93bkFjdGlvbikgPT4ge1xyXG4gICAgc3dpdGNoIChhY3Rpb24udHlwZSkge1xyXG4gICAgICAgIGNhc2UgJ0lOQ1JFTUVOVF9DT1VOVCc6XHJcbiAgICAgICAgICAgIHJldHVybiB7IGNvdW50OiBzdGF0ZS5jb3VudCArIDEgfTtcclxuICAgICAgICBjYXNlICdERUNSRU1FTlRfQ09VTlQnOlxyXG4gICAgICAgICAgICByZXR1cm4geyBjb3VudDogc3RhdGUuY291bnQgLSAxIH07XHJcbiAgICAgICAgZGVmYXVsdDpcclxuICAgICAgICAgICAgLy8gVGhlIGZvbGxvd2luZyBsaW5lIGd1YXJhbnRlZXMgdGhhdCBldmVyeSBhY3Rpb24gaW4gdGhlIEtub3duQWN0aW9uIHVuaW9uIGhhcyBiZWVuIGNvdmVyZWQgYnkgYSBjYXNlIGFib3ZlXHJcbiAgICAgICAgICAgIGNvbnN0IGV4aGF1c3RpdmVDaGVjazogbmV2ZXIgPSBhY3Rpb247XHJcbiAgICB9XHJcblxyXG4gICAgLy8gRm9yIHVucmVjb2duaXplZCBhY3Rpb25zIChvciBpbiBjYXNlcyB3aGVyZSBhY3Rpb25zIGhhdmUgbm8gZWZmZWN0KSwgbXVzdCByZXR1cm4gdGhlIGV4aXN0aW5nIHN0YXRlXHJcbiAgICAvLyAgKG9yIGRlZmF1bHQgaW5pdGlhbCBzdGF0ZSBpZiBub25lIHdhcyBzdXBwbGllZClcclxuICAgIHJldHVybiBzdGF0ZSB8fCB7IGNvdW50OiAwIH07XHJcbn07XHJcblxuXG5cbi8vIFdFQlBBQ0sgRk9PVEVSIC8vXG4vLyAuL0NsaWVudEFwcC9zdG9yZS9Db3VudGVyLnRzIiwiaW1wb3J0IHsgZmV0Y2gsIGFkZFRhc2sgfSBmcm9tICdkb21haW4tdGFzayc7XHJcbmltcG9ydCB7IEFjdGlvbiwgUmVkdWNlciwgQWN0aW9uQ3JlYXRvciB9IGZyb20gJ3JlZHV4JztcclxuaW1wb3J0IHsgQXBwVGh1bmtBY3Rpb24gfSBmcm9tICcuLyc7XHJcblxyXG4vLyAtLS0tLS0tLS0tLS0tLS0tLVxyXG4vLyBTVEFURSAtIFRoaXMgZGVmaW5lcyB0aGUgdHlwZSBvZiBkYXRhIG1haW50YWluZWQgaW4gdGhlIFJlZHV4IHN0b3JlLlxyXG5cclxuZXhwb3J0IGludGVyZmFjZSBXZWF0aGVyRm9yZWNhc3RzU3RhdGUge1xyXG4gICAgaXNMb2FkaW5nOiBib29sZWFuO1xyXG4gICAgc3RhcnREYXRlSW5kZXg/OiBudW1iZXI7XHJcbiAgICBmb3JlY2FzdHM6IFdlYXRoZXJGb3JlY2FzdFtdO1xyXG59XHJcblxyXG5leHBvcnQgaW50ZXJmYWNlIFdlYXRoZXJGb3JlY2FzdCB7XHJcbiAgICBkYXRlRm9ybWF0dGVkOiBzdHJpbmc7XHJcbiAgICB0ZW1wZXJhdHVyZUM6IG51bWJlcjtcclxuICAgIHRlbXBlcmF0dXJlRjogbnVtYmVyO1xyXG4gICAgc3VtbWFyeTogc3RyaW5nO1xyXG59XHJcblxyXG4vLyAtLS0tLS0tLS0tLS0tLS0tLVxyXG4vLyBBQ1RJT05TIC0gVGhlc2UgYXJlIHNlcmlhbGl6YWJsZSAoaGVuY2UgcmVwbGF5YWJsZSkgZGVzY3JpcHRpb25zIG9mIHN0YXRlIHRyYW5zaXRpb25zLlxyXG4vLyBUaGV5IGRvIG5vdCB0aGVtc2VsdmVzIGhhdmUgYW55IHNpZGUtZWZmZWN0czsgdGhleSBqdXN0IGRlc2NyaWJlIHNvbWV0aGluZyB0aGF0IGlzIGdvaW5nIHRvIGhhcHBlbi5cclxuXHJcbmludGVyZmFjZSBSZXF1ZXN0V2VhdGhlckZvcmVjYXN0c0FjdGlvbiB7XHJcbiAgICB0eXBlOiAnUkVRVUVTVF9XRUFUSEVSX0ZPUkVDQVNUUyc7XHJcbiAgICBzdGFydERhdGVJbmRleDogbnVtYmVyO1xyXG59XHJcblxyXG5pbnRlcmZhY2UgUmVjZWl2ZVdlYXRoZXJGb3JlY2FzdHNBY3Rpb24ge1xyXG4gICAgdHlwZTogJ1JFQ0VJVkVfV0VBVEhFUl9GT1JFQ0FTVFMnO1xyXG4gICAgc3RhcnREYXRlSW5kZXg6IG51bWJlcjtcclxuICAgIGZvcmVjYXN0czogV2VhdGhlckZvcmVjYXN0W107XHJcbn1cclxuXHJcbi8vIERlY2xhcmUgYSAnZGlzY3JpbWluYXRlZCB1bmlvbicgdHlwZS4gVGhpcyBndWFyYW50ZWVzIHRoYXQgYWxsIHJlZmVyZW5jZXMgdG8gJ3R5cGUnIHByb3BlcnRpZXMgY29udGFpbiBvbmUgb2YgdGhlXHJcbi8vIGRlY2xhcmVkIHR5cGUgc3RyaW5ncyAoYW5kIG5vdCBhbnkgb3RoZXIgYXJiaXRyYXJ5IHN0cmluZykuXHJcbnR5cGUgS25vd25BY3Rpb24gPSBSZXF1ZXN0V2VhdGhlckZvcmVjYXN0c0FjdGlvbiB8IFJlY2VpdmVXZWF0aGVyRm9yZWNhc3RzQWN0aW9uO1xyXG5cclxuLy8gLS0tLS0tLS0tLS0tLS0tLVxyXG4vLyBBQ1RJT04gQ1JFQVRPUlMgLSBUaGVzZSBhcmUgZnVuY3Rpb25zIGV4cG9zZWQgdG8gVUkgY29tcG9uZW50cyB0aGF0IHdpbGwgdHJpZ2dlciBhIHN0YXRlIHRyYW5zaXRpb24uXHJcbi8vIFRoZXkgZG9uJ3QgZGlyZWN0bHkgbXV0YXRlIHN0YXRlLCBidXQgdGhleSBjYW4gaGF2ZSBleHRlcm5hbCBzaWRlLWVmZmVjdHMgKHN1Y2ggYXMgbG9hZGluZyBkYXRhKS5cclxuXHJcbmV4cG9ydCBjb25zdCBhY3Rpb25DcmVhdG9ycyA9IHtcclxuICAgIHJlcXVlc3RXZWF0aGVyRm9yZWNhc3RzOiAoc3RhcnREYXRlSW5kZXg6IG51bWJlcik6IEFwcFRodW5rQWN0aW9uPEtub3duQWN0aW9uPiA9PiAoZGlzcGF0Y2gsIGdldFN0YXRlKSA9PiB7XHJcbiAgICAgICAgLy8gT25seSBsb2FkIGRhdGEgaWYgaXQncyBzb21ldGhpbmcgd2UgZG9uJ3QgYWxyZWFkeSBoYXZlIChhbmQgYXJlIG5vdCBhbHJlYWR5IGxvYWRpbmcpXHJcbiAgICAgICAgaWYgKHN0YXJ0RGF0ZUluZGV4ICE9PSBnZXRTdGF0ZSgpLndlYXRoZXJGb3JlY2FzdHMuc3RhcnREYXRlSW5kZXgpIHtcclxuICAgICAgICAgICAgbGV0IGZldGNoVGFzayA9IGZldGNoKGBhcGkvU2FtcGxlRGF0YS9XZWF0aGVyRm9yZWNhc3RzP3N0YXJ0RGF0ZUluZGV4PSR7IHN0YXJ0RGF0ZUluZGV4IH1gKVxyXG4gICAgICAgICAgICAgICAgLnRoZW4ocmVzcG9uc2UgPT4gcmVzcG9uc2UuanNvbigpIGFzIFByb21pc2U8V2VhdGhlckZvcmVjYXN0W10+KVxyXG4gICAgICAgICAgICAgICAgLnRoZW4oZGF0YSA9PiB7XHJcbiAgICAgICAgICAgICAgICAgICAgZGlzcGF0Y2goeyB0eXBlOiAnUkVDRUlWRV9XRUFUSEVSX0ZPUkVDQVNUUycsIHN0YXJ0RGF0ZUluZGV4OiBzdGFydERhdGVJbmRleCwgZm9yZWNhc3RzOiBkYXRhIH0pO1xyXG4gICAgICAgICAgICAgICAgfSk7XHJcblxyXG4gICAgICAgICAgICBhZGRUYXNrKGZldGNoVGFzayk7IC8vIEVuc3VyZSBzZXJ2ZXItc2lkZSBwcmVyZW5kZXJpbmcgd2FpdHMgZm9yIHRoaXMgdG8gY29tcGxldGVcclxuICAgICAgICAgICAgZGlzcGF0Y2goeyB0eXBlOiAnUkVRVUVTVF9XRUFUSEVSX0ZPUkVDQVNUUycsIHN0YXJ0RGF0ZUluZGV4OiBzdGFydERhdGVJbmRleCB9KTtcclxuICAgICAgICB9XHJcbiAgICB9XHJcbn07XHJcblxyXG4vLyAtLS0tLS0tLS0tLS0tLS0tXHJcbi8vIFJFRFVDRVIgLSBGb3IgYSBnaXZlbiBzdGF0ZSBhbmQgYWN0aW9uLCByZXR1cm5zIHRoZSBuZXcgc3RhdGUuIFRvIHN1cHBvcnQgdGltZSB0cmF2ZWwsIHRoaXMgbXVzdCBub3QgbXV0YXRlIHRoZSBvbGQgc3RhdGUuXHJcblxyXG5jb25zdCB1bmxvYWRlZFN0YXRlOiBXZWF0aGVyRm9yZWNhc3RzU3RhdGUgPSB7IGZvcmVjYXN0czogW10sIGlzTG9hZGluZzogZmFsc2UgfTtcclxuXHJcbmV4cG9ydCBjb25zdCByZWR1Y2VyOiBSZWR1Y2VyPFdlYXRoZXJGb3JlY2FzdHNTdGF0ZT4gPSAoc3RhdGU6IFdlYXRoZXJGb3JlY2FzdHNTdGF0ZSwgaW5jb21pbmdBY3Rpb246IEFjdGlvbikgPT4ge1xyXG4gICAgY29uc3QgYWN0aW9uID0gaW5jb21pbmdBY3Rpb24gYXMgS25vd25BY3Rpb247XHJcbiAgICBzd2l0Y2ggKGFjdGlvbi50eXBlKSB7XHJcbiAgICAgICAgY2FzZSAnUkVRVUVTVF9XRUFUSEVSX0ZPUkVDQVNUUyc6XHJcbiAgICAgICAgICAgIHJldHVybiB7XHJcbiAgICAgICAgICAgICAgICBzdGFydERhdGVJbmRleDogYWN0aW9uLnN0YXJ0RGF0ZUluZGV4LFxyXG4gICAgICAgICAgICAgICAgZm9yZWNhc3RzOiBzdGF0ZS5mb3JlY2FzdHMsXHJcbiAgICAgICAgICAgICAgICBpc0xvYWRpbmc6IHRydWVcclxuICAgICAgICAgICAgfTtcclxuICAgICAgICBjYXNlICdSRUNFSVZFX1dFQVRIRVJfRk9SRUNBU1RTJzpcclxuICAgICAgICAgICAgLy8gT25seSBhY2NlcHQgdGhlIGluY29taW5nIGRhdGEgaWYgaXQgbWF0Y2hlcyB0aGUgbW9zdCByZWNlbnQgcmVxdWVzdC4gVGhpcyBlbnN1cmVzIHdlIGNvcnJlY3RseVxyXG4gICAgICAgICAgICAvLyBoYW5kbGUgb3V0LW9mLW9yZGVyIHJlc3BvbnNlcy5cclxuICAgICAgICAgICAgaWYgKGFjdGlvbi5zdGFydERhdGVJbmRleCA9PT0gc3RhdGUuc3RhcnREYXRlSW5kZXgpIHtcclxuICAgICAgICAgICAgICAgIHJldHVybiB7XHJcbiAgICAgICAgICAgICAgICAgICAgc3RhcnREYXRlSW5kZXg6IGFjdGlvbi5zdGFydERhdGVJbmRleCxcclxuICAgICAgICAgICAgICAgICAgICBmb3JlY2FzdHM6IGFjdGlvbi5mb3JlY2FzdHMsXHJcbiAgICAgICAgICAgICAgICAgICAgaXNMb2FkaW5nOiBmYWxzZVxyXG4gICAgICAgICAgICAgICAgfTtcclxuICAgICAgICAgICAgfVxyXG4gICAgICAgICAgICBicmVhaztcclxuICAgICAgICBkZWZhdWx0OlxyXG4gICAgICAgICAgICAvLyBUaGUgZm9sbG93aW5nIGxpbmUgZ3VhcmFudGVlcyB0aGF0IGV2ZXJ5IGFjdGlvbiBpbiB0aGUgS25vd25BY3Rpb24gdW5pb24gaGFzIGJlZW4gY292ZXJlZCBieSBhIGNhc2UgYWJvdmVcclxuICAgICAgICAgICAgY29uc3QgZXhoYXVzdGl2ZUNoZWNrOiBuZXZlciA9IGFjdGlvbjtcclxuICAgIH1cclxuXHJcbiAgICByZXR1cm4gc3RhdGUgfHwgdW5sb2FkZWRTdGF0ZTtcclxufTtcclxuXG5cblxuLy8gV0VCUEFDSyBGT09URVIgLy9cbi8vIC4vQ2xpZW50QXBwL3N0b3JlL1dlYXRoZXJGb3JlY2FzdHMudHMiLCJpbXBvcnQgeyBjcmVhdGVTdG9yZSwgYXBwbHlNaWRkbGV3YXJlLCBjb21wb3NlLCBjb21iaW5lUmVkdWNlcnMsIEdlbmVyaWNTdG9yZUVuaGFuY2VyLCBTdG9yZSwgU3RvcmVFbmhhbmNlclN0b3JlQ3JlYXRvciwgUmVkdWNlcnNNYXBPYmplY3QgfSBmcm9tICdyZWR1eCc7XHJcbmltcG9ydCB0aHVuayBmcm9tICdyZWR1eC10aHVuayc7XHJcbmltcG9ydCB7IHJvdXRlclJlZHVjZXIsIHJvdXRlck1pZGRsZXdhcmUgfSBmcm9tICdyZWFjdC1yb3V0ZXItcmVkdXgnO1xyXG5pbXBvcnQgKiBhcyBTdG9yZU1vZHVsZSBmcm9tICcuL3N0b3JlJztcclxuaW1wb3J0IHsgQXBwbGljYXRpb25TdGF0ZSwgcmVkdWNlcnMgfSBmcm9tICcuL3N0b3JlJztcclxuaW1wb3J0IHsgSGlzdG9yeSB9IGZyb20gJ2hpc3RvcnknO1xyXG5cclxuZXhwb3J0IGRlZmF1bHQgZnVuY3Rpb24gY29uZmlndXJlU3RvcmUoaGlzdG9yeTogSGlzdG9yeSwgaW5pdGlhbFN0YXRlPzogQXBwbGljYXRpb25TdGF0ZSkge1xyXG4gICAgLy8gQnVpbGQgbWlkZGxld2FyZS4gVGhlc2UgYXJlIGZ1bmN0aW9ucyB0aGF0IGNhbiBwcm9jZXNzIHRoZSBhY3Rpb25zIGJlZm9yZSB0aGV5IHJlYWNoIHRoZSBzdG9yZS5cclxuICAgIGNvbnN0IHdpbmRvd0lmRGVmaW5lZCA9IHR5cGVvZiB3aW5kb3cgPT09ICd1bmRlZmluZWQnID8gbnVsbCA6IHdpbmRvdyBhcyBhbnk7XHJcbiAgICAvLyBJZiBkZXZUb29scyBpcyBpbnN0YWxsZWQsIGNvbm5lY3QgdG8gaXRcclxuICAgIGNvbnN0IGRldlRvb2xzRXh0ZW5zaW9uID0gd2luZG93SWZEZWZpbmVkICYmIHdpbmRvd0lmRGVmaW5lZC5fX1JFRFVYX0RFVlRPT0xTX0VYVEVOU0lPTl9fIGFzICgpID0+IEdlbmVyaWNTdG9yZUVuaGFuY2VyO1xyXG4gICAgY29uc3QgY3JlYXRlU3RvcmVXaXRoTWlkZGxld2FyZSA9IGNvbXBvc2UoXHJcbiAgICAgICAgYXBwbHlNaWRkbGV3YXJlKHRodW5rLCByb3V0ZXJNaWRkbGV3YXJlKGhpc3RvcnkpKSxcclxuICAgICAgICBkZXZUb29sc0V4dGVuc2lvbiA/IGRldlRvb2xzRXh0ZW5zaW9uKCkgOiA8Uz4obmV4dDogU3RvcmVFbmhhbmNlclN0b3JlQ3JlYXRvcjxTPikgPT4gbmV4dFxyXG4gICAgKShjcmVhdGVTdG9yZSk7XHJcblxyXG4gICAgLy8gQ29tYmluZSBhbGwgcmVkdWNlcnMgYW5kIGluc3RhbnRpYXRlIHRoZSBhcHAtd2lkZSBzdG9yZSBpbnN0YW5jZVxyXG4gICAgY29uc3QgYWxsUmVkdWNlcnMgPSBidWlsZFJvb3RSZWR1Y2VyKHJlZHVjZXJzKTtcclxuICAgIGNvbnN0IHN0b3JlID0gY3JlYXRlU3RvcmVXaXRoTWlkZGxld2FyZShhbGxSZWR1Y2VycywgaW5pdGlhbFN0YXRlKSBhcyBTdG9yZTxBcHBsaWNhdGlvblN0YXRlPjtcclxuXHJcbiAgICAvLyBFbmFibGUgV2VicGFjayBob3QgbW9kdWxlIHJlcGxhY2VtZW50IGZvciByZWR1Y2Vyc1xyXG4gICAgaWYgKG1vZHVsZS5ob3QpIHtcclxuICAgICAgICBtb2R1bGUuaG90LmFjY2VwdCgnLi9zdG9yZScsICgpID0+IHtcclxuICAgICAgICAgICAgY29uc3QgbmV4dFJvb3RSZWR1Y2VyID0gcmVxdWlyZTx0eXBlb2YgU3RvcmVNb2R1bGU+KCcuL3N0b3JlJyk7XHJcbiAgICAgICAgICAgIHN0b3JlLnJlcGxhY2VSZWR1Y2VyKGJ1aWxkUm9vdFJlZHVjZXIobmV4dFJvb3RSZWR1Y2VyLnJlZHVjZXJzKSk7XHJcbiAgICAgICAgfSk7XHJcbiAgICB9XHJcblxyXG4gICAgcmV0dXJuIHN0b3JlO1xyXG59XHJcblxyXG5mdW5jdGlvbiBidWlsZFJvb3RSZWR1Y2VyKGFsbFJlZHVjZXJzOiBSZWR1Y2Vyc01hcE9iamVjdCkge1xyXG4gICAgcmV0dXJuIGNvbWJpbmVSZWR1Y2VyczxBcHBsaWNhdGlvblN0YXRlPihPYmplY3QuYXNzaWduKHt9LCBhbGxSZWR1Y2VycywgeyByb3V0aW5nOiByb3V0ZXJSZWR1Y2VyIH0pKTtcclxufVxyXG5cblxuXG4vLyBXRUJQQUNLIEZPT1RFUiAvL1xuLy8gLi9DbGllbnRBcHAvY29uZmlndXJlU3RvcmUudHMiLCJpbXBvcnQgKiBhcyBSZWFjdCBmcm9tICdyZWFjdCc7XHJcbmltcG9ydCB7IFJvdXRlIH0gZnJvbSAncmVhY3Qtcm91dGVyLWRvbSc7XHJcbmltcG9ydCB7IExheW91dCB9IGZyb20gJy4vY29tcG9uZW50cy9MYXlvdXQnO1xyXG5pbXBvcnQgSG9tZSBmcm9tICcuL2NvbXBvbmVudHMvSG9tZSc7XHJcbmltcG9ydCBGZXRjaERhdGEgZnJvbSAnLi9jb21wb25lbnRzL0ZldGNoRGF0YSc7XHJcbmltcG9ydCBDb3VudGVyIGZyb20gJy4vY29tcG9uZW50cy9Db3VudGVyJztcclxuXHJcbmV4cG9ydCBjb25zdCByb3V0ZXMgPSA8TGF5b3V0PlxyXG4gICAgPFJvdXRlIGV4YWN0IHBhdGg9Jy8nIGNvbXBvbmVudD17IEhvbWUgfSAvPlxyXG4gICAgPFJvdXRlIHBhdGg9Jy9jb3VudGVyJyBjb21wb25lbnQ9eyBDb3VudGVyIH0gLz5cclxuICAgIDxSb3V0ZSBwYXRoPScvZmV0Y2hkYXRhLzpzdGFydERhdGVJbmRleD8nIGNvbXBvbmVudD17IEZldGNoRGF0YSB9IC8+XHJcbjwvTGF5b3V0PjtcclxuXG5cblxuLy8gV0VCUEFDSyBGT09URVIgLy9cbi8vIC4vQ2xpZW50QXBwL3JvdXRlcy50c3giLCJtb2R1bGUuZXhwb3J0cyA9IChfX3dlYnBhY2tfcmVxdWlyZV9fKDApKSgxMzIpO1xuXG5cbi8vLy8vLy8vLy8vLy8vLy8vL1xuLy8gV0VCUEFDSyBGT09URVJcbi8vIGRlbGVnYXRlZCAuL25vZGVfbW9kdWxlcy9hc3BuZXQtcHJlcmVuZGVyaW5nL2luZGV4LmpzIGZyb20gZGxsLXJlZmVyZW5jZSAuL3ZlbmRvclxuLy8gbW9kdWxlIGlkID0gOVxuLy8gbW9kdWxlIGNodW5rcyA9IDAiLCJtb2R1bGUuZXhwb3J0cyA9IChfX3dlYnBhY2tfcmVxdWlyZV9fKDApKSgxMzcpO1xuXG5cbi8vLy8vLy8vLy8vLy8vLy8vL1xuLy8gV0VCUEFDSyBGT09URVJcbi8vIGRlbGVnYXRlZCAuL25vZGVfbW9kdWxlcy9oaXN0b3J5L2luZGV4LmpzIGZyb20gZGxsLXJlZmVyZW5jZSAuL3ZlbmRvclxuLy8gbW9kdWxlIGlkID0gMTBcbi8vIG1vZHVsZSBjaHVua3MgPSAwIiwibW9kdWxlLmV4cG9ydHMgPSAoX193ZWJwYWNrX3JlcXVpcmVfXygwKSkoMTM5KTtcblxuXG4vLy8vLy8vLy8vLy8vLy8vLy9cbi8vIFdFQlBBQ0sgRk9PVEVSXG4vLyBkZWxlZ2F0ZWQgLi9ub2RlX21vZHVsZXMvcmVhY3QtZG9tL3NlcnZlci5qcyBmcm9tIGRsbC1yZWZlcmVuY2UgLi92ZW5kb3Jcbi8vIG1vZHVsZSBpZCA9IDExXG4vLyBtb2R1bGUgY2h1bmtzID0gMCIsImltcG9ydCAqIGFzIFJlYWN0IGZyb20gJ3JlYWN0JztcclxuaW1wb3J0IHsgUHJvdmlkZXIgfSBmcm9tICdyZWFjdC1yZWR1eCc7XHJcbmltcG9ydCB7IHJlbmRlclRvU3RyaW5nIH0gZnJvbSAncmVhY3QtZG9tL3NlcnZlcic7XHJcbmltcG9ydCB7IFN0YXRpY1JvdXRlciB9IGZyb20gJ3JlYWN0LXJvdXRlci1kb20nO1xyXG5pbXBvcnQgeyByZXBsYWNlIH0gZnJvbSAncmVhY3Qtcm91dGVyLXJlZHV4JztcclxuaW1wb3J0IHsgY3JlYXRlTWVtb3J5SGlzdG9yeSB9IGZyb20gJ2hpc3RvcnknO1xyXG5pbXBvcnQgeyBjcmVhdGVTZXJ2ZXJSZW5kZXJlciwgUmVuZGVyUmVzdWx0IH0gZnJvbSAnYXNwbmV0LXByZXJlbmRlcmluZyc7XHJcbmltcG9ydCB7IHJvdXRlcyB9IGZyb20gJy4vcm91dGVzJztcclxuaW1wb3J0IGNvbmZpZ3VyZVN0b3JlIGZyb20gJy4vY29uZmlndXJlU3RvcmUnO1xyXG5cclxuZXhwb3J0IGRlZmF1bHQgY3JlYXRlU2VydmVyUmVuZGVyZXIocGFyYW1zID0+IHtcclxuICAgIHJldHVybiBuZXcgUHJvbWlzZTxSZW5kZXJSZXN1bHQ+KChyZXNvbHZlLCByZWplY3QpID0+IHtcclxuICAgICAgICAvLyBQcmVwYXJlIFJlZHV4IHN0b3JlIHdpdGggaW4tbWVtb3J5IGhpc3RvcnksIGFuZCBkaXNwYXRjaCBhIG5hdmlnYXRpb24gZXZlbnRcclxuICAgICAgICAvLyBjb3JyZXNwb25kaW5nIHRvIHRoZSBpbmNvbWluZyBVUkxcclxuICAgICAgICBjb25zdCBiYXNlbmFtZSA9IHBhcmFtcy5iYXNlVXJsLnN1YnN0cmluZygwLCBwYXJhbXMuYmFzZVVybC5sZW5ndGggLSAxKTsgLy8gUmVtb3ZlIHRyYWlsaW5nIHNsYXNoXHJcbiAgICAgICAgY29uc3QgdXJsQWZ0ZXJCYXNlbmFtZSA9IHBhcmFtcy51cmwuc3Vic3RyaW5nKGJhc2VuYW1lLmxlbmd0aCk7XHJcbiAgICAgICAgY29uc3Qgc3RvcmUgPSBjb25maWd1cmVTdG9yZShjcmVhdGVNZW1vcnlIaXN0b3J5KCkpO1xyXG4gICAgICAgIHN0b3JlLmRpc3BhdGNoKHJlcGxhY2UodXJsQWZ0ZXJCYXNlbmFtZSkpO1xyXG5cclxuICAgICAgICAvLyBQcmVwYXJlIGFuIGluc3RhbmNlIG9mIHRoZSBhcHBsaWNhdGlvbiBhbmQgcGVyZm9ybSBhbiBpbml0YWwgcmVuZGVyIHRoYXQgd2lsbFxyXG4gICAgICAgIC8vIGNhdXNlIGFueSBhc3luYyB0YXNrcyAoZS5nLiwgZGF0YSBhY2Nlc3MpIHRvIGJlZ2luXHJcbiAgICAgICAgY29uc3Qgcm91dGVyQ29udGV4dDogYW55ID0ge307XHJcbiAgICAgICAgY29uc3QgYXBwID0gKFxyXG4gICAgICAgICAgICA8UHJvdmlkZXIgc3RvcmU9eyBzdG9yZSB9PlxyXG4gICAgICAgICAgICAgICAgPFN0YXRpY1JvdXRlciBiYXNlbmFtZT17IGJhc2VuYW1lIH0gY29udGV4dD17IHJvdXRlckNvbnRleHQgfSBsb2NhdGlvbj17IHBhcmFtcy5sb2NhdGlvbi5wYXRoIH0gY2hpbGRyZW49eyByb3V0ZXMgfSAvPlxyXG4gICAgICAgICAgICA8L1Byb3ZpZGVyPlxyXG4gICAgICAgICk7XHJcbiAgICAgICAgcmVuZGVyVG9TdHJpbmcoYXBwKTtcclxuXHJcbiAgICAgICAgLy8gSWYgdGhlcmUncyBhIHJlZGlyZWN0aW9uLCBqdXN0IHNlbmQgdGhpcyBpbmZvcm1hdGlvbiBiYWNrIHRvIHRoZSBob3N0IGFwcGxpY2F0aW9uXHJcbiAgICAgICAgaWYgKHJvdXRlckNvbnRleHQudXJsKSB7XHJcbiAgICAgICAgICAgIHJlc29sdmUoeyByZWRpcmVjdFVybDogcm91dGVyQ29udGV4dC51cmwgfSk7XHJcbiAgICAgICAgICAgIHJldHVybjtcclxuICAgICAgICB9XHJcbiAgICAgICAgXHJcbiAgICAgICAgLy8gT25jZSBhbnkgYXN5bmMgdGFza3MgYXJlIGRvbmUsIHdlIGNhbiBwZXJmb3JtIHRoZSBmaW5hbCByZW5kZXJcclxuICAgICAgICAvLyBXZSBhbHNvIHNlbmQgdGhlIHJlZHV4IHN0b3JlIHN0YXRlLCBzbyB0aGUgY2xpZW50IGNhbiBjb250aW51ZSBleGVjdXRpb24gd2hlcmUgdGhlIHNlcnZlciBsZWZ0IG9mZlxyXG4gICAgICAgIHBhcmFtcy5kb21haW5UYXNrcy50aGVuKCgpID0+IHtcclxuICAgICAgICAgICAgcmVzb2x2ZSh7XHJcbiAgICAgICAgICAgICAgICBodG1sOiByZW5kZXJUb1N0cmluZyhhcHApLFxyXG4gICAgICAgICAgICAgICAgZ2xvYmFsczogeyBpbml0aWFsUmVkdXhTdGF0ZTogc3RvcmUuZ2V0U3RhdGUoKSB9XHJcbiAgICAgICAgICAgIH0pO1xyXG4gICAgICAgIH0sIHJlamVjdCk7IC8vIEFsc28gcHJvcGFnYXRlIGFueSBlcnJvcnMgYmFjayBpbnRvIHRoZSBob3N0IGFwcGxpY2F0aW9uXHJcbiAgICB9KTtcclxufSk7XHJcblxuXG5cbi8vIFdFQlBBQ0sgRk9PVEVSIC8vXG4vLyAuL0NsaWVudEFwcC9ib290LXNlcnZlci50c3giLCJpbXBvcnQgKiBhcyBSZWFjdCBmcm9tICdyZWFjdCc7XHJcbmltcG9ydCB7IExpbmssIFJvdXRlQ29tcG9uZW50UHJvcHMgfSBmcm9tICdyZWFjdC1yb3V0ZXItZG9tJztcclxuaW1wb3J0IHsgY29ubmVjdCB9IGZyb20gJ3JlYWN0LXJlZHV4JztcclxuaW1wb3J0IHsgQXBwbGljYXRpb25TdGF0ZSB9ICBmcm9tICcuLi9zdG9yZSc7XHJcbmltcG9ydCAqIGFzIENvdW50ZXJTdG9yZSBmcm9tICcuLi9zdG9yZS9Db3VudGVyJztcclxuaW1wb3J0ICogYXMgV2VhdGhlckZvcmVjYXN0cyBmcm9tICcuLi9zdG9yZS9XZWF0aGVyRm9yZWNhc3RzJztcclxuXHJcbnR5cGUgQ291bnRlclByb3BzID1cclxuICAgIENvdW50ZXJTdG9yZS5Db3VudGVyU3RhdGVcclxuICAgICYgdHlwZW9mIENvdW50ZXJTdG9yZS5hY3Rpb25DcmVhdG9yc1xyXG4gICAgJiBSb3V0ZUNvbXBvbmVudFByb3BzPHt9PjtcclxuXHJcbmNsYXNzIENvdW50ZXIgZXh0ZW5kcyBSZWFjdC5Db21wb25lbnQ8Q291bnRlclByb3BzLCB7fT4ge1xyXG4gICAgcHVibGljIHJlbmRlcigpIHtcclxuICAgICAgICByZXR1cm4gPGRpdj5cclxuICAgICAgICAgICAgPGgxPkNvdW50ZXI8L2gxPlxyXG5cclxuICAgICAgICAgICAgPHA+VGhpcyBpcyBhIHNpbXBsZSBleGFtcGxlIG9mIGEgUmVhY3QgY29tcG9uZW50LjwvcD5cclxuXHJcbiAgICAgICAgICAgIDxwPkN1cnJlbnQgY291bnQ6IDxzdHJvbmc+eyB0aGlzLnByb3BzLmNvdW50IH08L3N0cm9uZz48L3A+XHJcblxyXG4gICAgICAgICAgICA8YnV0dG9uIG9uQ2xpY2s9eyAoKSA9PiB7IHRoaXMucHJvcHMuaW5jcmVtZW50KCkgfSB9PkluY3JlbWVudDwvYnV0dG9uPlxyXG4gICAgICAgIDwvZGl2PjtcclxuICAgIH1cclxufVxyXG5cclxuLy8gV2lyZSB1cCB0aGUgUmVhY3QgY29tcG9uZW50IHRvIHRoZSBSZWR1eCBzdG9yZVxyXG5leHBvcnQgZGVmYXVsdCBjb25uZWN0KFxyXG4gICAgKHN0YXRlOiBBcHBsaWNhdGlvblN0YXRlKSA9PiBzdGF0ZS5jb3VudGVyLCAvLyBTZWxlY3RzIHdoaWNoIHN0YXRlIHByb3BlcnRpZXMgYXJlIG1lcmdlZCBpbnRvIHRoZSBjb21wb25lbnQncyBwcm9wc1xyXG4gICAgQ291bnRlclN0b3JlLmFjdGlvbkNyZWF0b3JzICAgICAgICAgICAgICAgICAvLyBTZWxlY3RzIHdoaWNoIGFjdGlvbiBjcmVhdG9ycyBhcmUgbWVyZ2VkIGludG8gdGhlIGNvbXBvbmVudCdzIHByb3BzXHJcbikoQ291bnRlcikgYXMgdHlwZW9mIENvdW50ZXI7XG5cblxuLy8gV0VCUEFDSyBGT09URVIgLy9cbi8vIC4vQ2xpZW50QXBwL2NvbXBvbmVudHMvQ291bnRlci50c3giLCJpbXBvcnQgKiBhcyBSZWFjdCBmcm9tICdyZWFjdCc7XHJcbmltcG9ydCB7IExpbmssIFJvdXRlQ29tcG9uZW50UHJvcHMgfSBmcm9tICdyZWFjdC1yb3V0ZXItZG9tJztcclxuaW1wb3J0IHsgY29ubmVjdCB9IGZyb20gJ3JlYWN0LXJlZHV4JztcclxuaW1wb3J0IHsgQXBwbGljYXRpb25TdGF0ZSB9ICBmcm9tICcuLi9zdG9yZSc7XHJcbmltcG9ydCAqIGFzIFdlYXRoZXJGb3JlY2FzdHNTdGF0ZSBmcm9tICcuLi9zdG9yZS9XZWF0aGVyRm9yZWNhc3RzJztcclxuXHJcbi8vIEF0IHJ1bnRpbWUsIFJlZHV4IHdpbGwgbWVyZ2UgdG9nZXRoZXIuLi5cclxudHlwZSBXZWF0aGVyRm9yZWNhc3RQcm9wcyA9XHJcbiAgICBXZWF0aGVyRm9yZWNhc3RzU3RhdGUuV2VhdGhlckZvcmVjYXN0c1N0YXRlICAgICAgICAvLyAuLi4gc3RhdGUgd2UndmUgcmVxdWVzdGVkIGZyb20gdGhlIFJlZHV4IHN0b3JlXHJcbiAgICAmIHR5cGVvZiBXZWF0aGVyRm9yZWNhc3RzU3RhdGUuYWN0aW9uQ3JlYXRvcnMgICAgICAvLyAuLi4gcGx1cyBhY3Rpb24gY3JlYXRvcnMgd2UndmUgcmVxdWVzdGVkXHJcbiAgICAmIFJvdXRlQ29tcG9uZW50UHJvcHM8eyBzdGFydERhdGVJbmRleDogc3RyaW5nIH0+OyAvLyAuLi4gcGx1cyBpbmNvbWluZyByb3V0aW5nIHBhcmFtZXRlcnNcclxuXHJcbmNsYXNzIEZldGNoRGF0YSBleHRlbmRzIFJlYWN0LkNvbXBvbmVudDxXZWF0aGVyRm9yZWNhc3RQcm9wcywge30+IHtcclxuICAgIGNvbXBvbmVudFdpbGxNb3VudCgpIHtcclxuICAgICAgICAvLyBUaGlzIG1ldGhvZCBydW5zIHdoZW4gdGhlIGNvbXBvbmVudCBpcyBmaXJzdCBhZGRlZCB0byB0aGUgcGFnZVxyXG4gICAgICAgIGxldCBzdGFydERhdGVJbmRleCA9IHBhcnNlSW50KHRoaXMucHJvcHMubWF0Y2gucGFyYW1zLnN0YXJ0RGF0ZUluZGV4KSB8fCAwO1xyXG4gICAgICAgIHRoaXMucHJvcHMucmVxdWVzdFdlYXRoZXJGb3JlY2FzdHMoc3RhcnREYXRlSW5kZXgpO1xyXG4gICAgfVxyXG5cclxuICAgIGNvbXBvbmVudFdpbGxSZWNlaXZlUHJvcHMobmV4dFByb3BzOiBXZWF0aGVyRm9yZWNhc3RQcm9wcykge1xyXG4gICAgICAgIC8vIFRoaXMgbWV0aG9kIHJ1bnMgd2hlbiBpbmNvbWluZyBwcm9wcyAoZS5nLiwgcm91dGUgcGFyYW1zKSBjaGFuZ2VcclxuICAgICAgICBsZXQgc3RhcnREYXRlSW5kZXggPSBwYXJzZUludChuZXh0UHJvcHMubWF0Y2gucGFyYW1zLnN0YXJ0RGF0ZUluZGV4KSB8fCAwO1xyXG4gICAgICAgIHRoaXMucHJvcHMucmVxdWVzdFdlYXRoZXJGb3JlY2FzdHMoc3RhcnREYXRlSW5kZXgpO1xyXG4gICAgfVxyXG5cclxuICAgIHB1YmxpYyByZW5kZXIoKSB7XHJcbiAgICAgICAgcmV0dXJuIDxkaXY+XHJcbiAgICAgICAgICAgIDxoMT5XZWF0aGVyIGZvcmVjYXN0PC9oMT5cclxuICAgICAgICAgICAgPHA+VGhpcyBjb21wb25lbnQgZGVtb25zdHJhdGVzIGZldGNoaW5nIGRhdGEgZnJvbSB0aGUgc2VydmVyIGFuZCB3b3JraW5nIHdpdGggVVJMIHBhcmFtZXRlcnMuPC9wPlxyXG4gICAgICAgICAgICB7IHRoaXMucmVuZGVyRm9yZWNhc3RzVGFibGUoKSB9XHJcbiAgICAgICAgICAgIHsgdGhpcy5yZW5kZXJQYWdpbmF0aW9uKCkgfVxyXG4gICAgICAgIDwvZGl2PjtcclxuICAgIH1cclxuXHJcbiAgICBwcml2YXRlIHJlbmRlckZvcmVjYXN0c1RhYmxlKCkge1xyXG4gICAgICAgIHJldHVybiA8dGFibGUgY2xhc3NOYW1lPSd0YWJsZSc+XHJcbiAgICAgICAgICAgIDx0aGVhZD5cclxuICAgICAgICAgICAgICAgIDx0cj5cclxuICAgICAgICAgICAgICAgICAgICA8dGg+RGF0ZTwvdGg+XHJcbiAgICAgICAgICAgICAgICAgICAgPHRoPlRlbXAuIChDKTwvdGg+XHJcbiAgICAgICAgICAgICAgICAgICAgPHRoPlRlbXAuIChGKTwvdGg+XHJcbiAgICAgICAgICAgICAgICAgICAgPHRoPlN1bW1hcnk8L3RoPlxyXG4gICAgICAgICAgICAgICAgPC90cj5cclxuICAgICAgICAgICAgPC90aGVhZD5cclxuICAgICAgICAgICAgPHRib2R5PlxyXG4gICAgICAgICAgICB7dGhpcy5wcm9wcy5mb3JlY2FzdHMubWFwKGZvcmVjYXN0ID0+XHJcbiAgICAgICAgICAgICAgICA8dHIga2V5PXsgZm9yZWNhc3QuZGF0ZUZvcm1hdHRlZCB9PlxyXG4gICAgICAgICAgICAgICAgICAgIDx0ZD57IGZvcmVjYXN0LmRhdGVGb3JtYXR0ZWQgfTwvdGQ+XHJcbiAgICAgICAgICAgICAgICAgICAgPHRkPnsgZm9yZWNhc3QudGVtcGVyYXR1cmVDIH08L3RkPlxyXG4gICAgICAgICAgICAgICAgICAgIDx0ZD57IGZvcmVjYXN0LnRlbXBlcmF0dXJlRiB9PC90ZD5cclxuICAgICAgICAgICAgICAgICAgICA8dGQ+eyBmb3JlY2FzdC5zdW1tYXJ5IH08L3RkPlxyXG4gICAgICAgICAgICAgICAgPC90cj5cclxuICAgICAgICAgICAgKX1cclxuICAgICAgICAgICAgPC90Ym9keT5cclxuICAgICAgICA8L3RhYmxlPjtcclxuICAgIH1cclxuXHJcbiAgICBwcml2YXRlIHJlbmRlclBhZ2luYXRpb24oKSB7XHJcbiAgICAgICAgbGV0IHByZXZTdGFydERhdGVJbmRleCA9ICh0aGlzLnByb3BzLnN0YXJ0RGF0ZUluZGV4IHx8IDApIC0gNTtcclxuICAgICAgICBsZXQgbmV4dFN0YXJ0RGF0ZUluZGV4ID0gKHRoaXMucHJvcHMuc3RhcnREYXRlSW5kZXggfHwgMCkgKyA1O1xyXG5cclxuICAgICAgICByZXR1cm4gPHAgY2xhc3NOYW1lPSdjbGVhcmZpeCB0ZXh0LWNlbnRlcic+XHJcbiAgICAgICAgICAgIDxMaW5rIGNsYXNzTmFtZT0nYnRuIGJ0bi1kZWZhdWx0IHB1bGwtbGVmdCcgdG89eyBgL2ZldGNoZGF0YS8keyBwcmV2U3RhcnREYXRlSW5kZXggfWAgfT5QcmV2aW91czwvTGluaz5cclxuICAgICAgICAgICAgPExpbmsgY2xhc3NOYW1lPSdidG4gYnRuLWRlZmF1bHQgcHVsbC1yaWdodCcgdG89eyBgL2ZldGNoZGF0YS8keyBuZXh0U3RhcnREYXRlSW5kZXggfWAgfT5OZXh0PC9MaW5rPlxyXG4gICAgICAgICAgICB7IHRoaXMucHJvcHMuaXNMb2FkaW5nID8gPHNwYW4+TG9hZGluZy4uLjwvc3Bhbj4gOiBbXSB9XHJcbiAgICAgICAgPC9wPjtcclxuICAgIH1cclxufVxyXG5cclxuZXhwb3J0IGRlZmF1bHQgY29ubmVjdChcclxuICAgIChzdGF0ZTogQXBwbGljYXRpb25TdGF0ZSkgPT4gc3RhdGUud2VhdGhlckZvcmVjYXN0cywgLy8gU2VsZWN0cyB3aGljaCBzdGF0ZSBwcm9wZXJ0aWVzIGFyZSBtZXJnZWQgaW50byB0aGUgY29tcG9uZW50J3MgcHJvcHNcclxuICAgIFdlYXRoZXJGb3JlY2FzdHNTdGF0ZS5hY3Rpb25DcmVhdG9ycyAgICAgICAgICAgICAgICAgLy8gU2VsZWN0cyB3aGljaCBhY3Rpb24gY3JlYXRvcnMgYXJlIG1lcmdlZCBpbnRvIHRoZSBjb21wb25lbnQncyBwcm9wc1xyXG4pKEZldGNoRGF0YSkgYXMgdHlwZW9mIEZldGNoRGF0YTtcclxuXG5cblxuLy8gV0VCUEFDSyBGT09URVIgLy9cbi8vIC4vQ2xpZW50QXBwL2NvbXBvbmVudHMvRmV0Y2hEYXRhLnRzeCIsImltcG9ydCAqIGFzIFJlYWN0IGZyb20gJ3JlYWN0JztcclxuaW1wb3J0IHsgUm91dGVDb21wb25lbnRQcm9wcyB9IGZyb20gJ3JlYWN0LXJvdXRlci1kb20nO1xyXG5cclxuZXhwb3J0IGRlZmF1bHQgY2xhc3MgSG9tZSBleHRlbmRzIFJlYWN0LkNvbXBvbmVudDxSb3V0ZUNvbXBvbmVudFByb3BzPHt9Piwge30+IHtcclxuICAgIHB1YmxpYyByZW5kZXIoKSB7XHJcbiAgICAgICAgcmV0dXJuIDxkaXY+XHJcbiAgICAgICAgICAgIDxoMT5IZWxsbywgd29ybGQhPC9oMT5cclxuICAgICAgICAgICAgPHA+V2VsY29tZSB0byB5b3VyIG5ldyBzaW5nbGUtcGFnZSBhcHBsaWNhdGlvbiwgYnVpbHQgd2l0aDo8L3A+XHJcbiAgICAgICAgICAgIDx1bD5cclxuICAgICAgICAgICAgICAgIDxsaT48YSBocmVmPSdodHRwczovL2dldC5hc3AubmV0Lyc+QVNQLk5FVCBDb3JlPC9hPiBhbmQgPGEgaHJlZj0naHR0cHM6Ly9tc2RuLm1pY3Jvc29mdC5jb20vZW4tdXMvbGlicmFyeS82N2VmOHNiZC5hc3B4Jz5DIzwvYT4gZm9yIGNyb3NzLXBsYXRmb3JtIHNlcnZlci1zaWRlIGNvZGU8L2xpPlxyXG4gICAgICAgICAgICAgICAgPGxpPjxhIGhyZWY9J2h0dHBzOi8vZmFjZWJvb2suZ2l0aHViLmlvL3JlYWN0Lyc+UmVhY3Q8L2E+LCA8YSBocmVmPSdodHRwOi8vcmVkdXguanMub3JnJz5SZWR1eDwvYT4sIGFuZCA8YSBocmVmPSdodHRwOi8vd3d3LnR5cGVzY3JpcHRsYW5nLm9yZy8nPlR5cGVTY3JpcHQ8L2E+IGZvciBjbGllbnQtc2lkZSBjb2RlPC9saT5cclxuICAgICAgICAgICAgICAgIDxsaT48YSBocmVmPSdodHRwczovL3dlYnBhY2suZ2l0aHViLmlvLyc+V2VicGFjazwvYT4gZm9yIGJ1aWxkaW5nIGFuZCBidW5kbGluZyBjbGllbnQtc2lkZSByZXNvdXJjZXM8L2xpPlxyXG4gICAgICAgICAgICAgICAgPGxpPjxhIGhyZWY9J2h0dHA6Ly9nZXRib290c3RyYXAuY29tLyc+Qm9vdHN0cmFwPC9hPiBmb3IgbGF5b3V0IGFuZCBzdHlsaW5nPC9saT5cclxuICAgICAgICAgICAgPC91bD5cclxuICAgICAgICAgICAgPHA+VG8gaGVscCB5b3UgZ2V0IHN0YXJ0ZWQsIHdlJ3ZlIGFsc28gc2V0IHVwOjwvcD5cclxuICAgICAgICAgICAgPHVsPlxyXG4gICAgICAgICAgICAgICAgPGxpPjxzdHJvbmc+Q2xpZW50LXNpZGUgbmF2aWdhdGlvbjwvc3Ryb25nPi4gRm9yIGV4YW1wbGUsIGNsaWNrIDxlbT5Db3VudGVyPC9lbT4gdGhlbiA8ZW0+QmFjazwvZW0+IHRvIHJldHVybiBoZXJlLjwvbGk+XHJcbiAgICAgICAgICAgICAgICA8bGk+PHN0cm9uZz5XZWJwYWNrIGRldiBtaWRkbGV3YXJlPC9zdHJvbmc+LiBJbiBkZXZlbG9wbWVudCBtb2RlLCB0aGVyZSdzIG5vIG5lZWQgdG8gcnVuIHRoZSA8Y29kZT53ZWJwYWNrPC9jb2RlPiBidWlsZCB0b29sLiBZb3VyIGNsaWVudC1zaWRlIHJlc291cmNlcyBhcmUgZHluYW1pY2FsbHkgYnVpbHQgb24gZGVtYW5kLiBVcGRhdGVzIGFyZSBhdmFpbGFibGUgYXMgc29vbiBhcyB5b3UgbW9kaWZ5IGFueSBmaWxlLjwvbGk+XHJcbiAgICAgICAgICAgICAgICA8bGk+PHN0cm9uZz5Ib3QgbW9kdWxlIHJlcGxhY2VtZW50PC9zdHJvbmc+LiBJbiBkZXZlbG9wbWVudCBtb2RlLCB5b3UgZG9uJ3QgZXZlbiBuZWVkIHRvIHJlbG9hZCB0aGUgcGFnZSBhZnRlciBtYWtpbmcgbW9zdCBjaGFuZ2VzLiBXaXRoaW4gc2Vjb25kcyBvZiBzYXZpbmcgY2hhbmdlcyB0byBmaWxlcywgcmVidWlsdCBSZWFjdCBjb21wb25lbnRzIHdpbGwgYmUgaW5qZWN0ZWQgZGlyZWN0bHkgaW50byB5b3VyIHJ1bm5pbmcgYXBwbGljYXRpb24sIHByZXNlcnZpbmcgaXRzIGxpdmUgc3RhdGUuPC9saT5cclxuICAgICAgICAgICAgICAgIDxsaT48c3Ryb25nPkVmZmljaWVudCBwcm9kdWN0aW9uIGJ1aWxkczwvc3Ryb25nPi4gSW4gcHJvZHVjdGlvbiBtb2RlLCBkZXZlbG9wbWVudC10aW1lIGZlYXR1cmVzIGFyZSBkaXNhYmxlZCwgYW5kIHRoZSA8Y29kZT53ZWJwYWNrPC9jb2RlPiBidWlsZCB0b29sIHByb2R1Y2VzIG1pbmlmaWVkIHN0YXRpYyBDU1MgYW5kIEphdmFTY3JpcHQgZmlsZXMuPC9saT5cclxuICAgICAgICAgICAgICAgIDxsaT48c3Ryb25nPlNlcnZlci1zaWRlIHByZXJlbmRlcmluZzwvc3Ryb25nPi4gVG8gb3B0aW1pemUgc3RhcnR1cCB0aW1lLCB5b3VyIFJlYWN0IGFwcGxpY2F0aW9uIGlzIGZpcnN0IHJlbmRlcmVkIG9uIHRoZSBzZXJ2ZXIuIFRoZSBpbml0aWFsIEhUTUwgYW5kIHN0YXRlIGlzIHRoZW4gdHJhbnNmZXJyZWQgdG8gdGhlIGJyb3dzZXIsIHdoZXJlIGNsaWVudC1zaWRlIGNvZGUgcGlja3MgdXAgd2hlcmUgdGhlIHNlcnZlciBsZWZ0IG9mZi48L2xpPlxyXG4gICAgICAgICAgICA8L3VsPlxyXG4gICAgICAgIDwvZGl2PjtcclxuICAgIH1cclxufVxyXG5cblxuXG4vLyBXRUJQQUNLIEZPT1RFUiAvL1xuLy8gLi9DbGllbnRBcHAvY29tcG9uZW50cy9Ib21lLnRzeCIsImltcG9ydCAqIGFzIFJlYWN0IGZyb20gJ3JlYWN0JztcclxuaW1wb3J0IHsgTmF2TWVudSB9IGZyb20gJy4vTmF2TWVudSc7XHJcblxyXG5leHBvcnQgY2xhc3MgTGF5b3V0IGV4dGVuZHMgUmVhY3QuQ29tcG9uZW50PHt9LCB7fT4ge1xyXG4gICAgcHVibGljIHJlbmRlcigpIHtcclxuICAgICAgICByZXR1cm4gPGRpdiBjbGFzc05hbWU9J2NvbnRhaW5lci1mbHVpZCc+XHJcbiAgICAgICAgICAgIDxkaXYgY2xhc3NOYW1lPSdyb3cnPlxyXG4gICAgICAgICAgICAgICAgPGRpdiBjbGFzc05hbWU9J2NvbC1zbS0zJz5cclxuICAgICAgICAgICAgICAgICAgICA8TmF2TWVudSAvPlxyXG4gICAgICAgICAgICAgICAgPC9kaXY+XHJcbiAgICAgICAgICAgICAgICA8ZGl2IGNsYXNzTmFtZT0nY29sLXNtLTknPlxyXG4gICAgICAgICAgICAgICAgICAgIHsgdGhpcy5wcm9wcy5jaGlsZHJlbiB9XHJcbiAgICAgICAgICAgICAgICA8L2Rpdj5cclxuICAgICAgICAgICAgPC9kaXY+XHJcbiAgICAgICAgPC9kaXY+O1xyXG4gICAgfVxyXG59XHJcblxuXG5cbi8vIFdFQlBBQ0sgRk9PVEVSIC8vXG4vLyAuL0NsaWVudEFwcC9jb21wb25lbnRzL0xheW91dC50c3giLCJpbXBvcnQgKiBhcyBSZWFjdCBmcm9tICdyZWFjdCc7XHJcbmltcG9ydCB7IE5hdkxpbmssIExpbmsgfSBmcm9tICdyZWFjdC1yb3V0ZXItZG9tJztcclxuXHJcbmV4cG9ydCBjbGFzcyBOYXZNZW51IGV4dGVuZHMgUmVhY3QuQ29tcG9uZW50PHt9LCB7fT4ge1xyXG4gICAgcHVibGljIHJlbmRlcigpIHtcclxuICAgICAgICByZXR1cm4gPGRpdiBjbGFzc05hbWU9J21haW4tbmF2Jz5cclxuICAgICAgICAgICAgICAgIDxkaXYgY2xhc3NOYW1lPSduYXZiYXIgbmF2YmFyLWludmVyc2UnPlxyXG4gICAgICAgICAgICAgICAgPGRpdiBjbGFzc05hbWU9J25hdmJhci1oZWFkZXInPlxyXG4gICAgICAgICAgICAgICAgICAgIDxidXR0b24gdHlwZT0nYnV0dG9uJyBjbGFzc05hbWU9J25hdmJhci10b2dnbGUnIGRhdGEtdG9nZ2xlPSdjb2xsYXBzZScgZGF0YS10YXJnZXQ9Jy5uYXZiYXItY29sbGFwc2UnPlxyXG4gICAgICAgICAgICAgICAgICAgICAgICA8c3BhbiBjbGFzc05hbWU9J3NyLW9ubHknPlRvZ2dsZSBuYXZpZ2F0aW9uPC9zcGFuPlxyXG4gICAgICAgICAgICAgICAgICAgICAgICA8c3BhbiBjbGFzc05hbWU9J2ljb24tYmFyJz48L3NwYW4+XHJcbiAgICAgICAgICAgICAgICAgICAgICAgIDxzcGFuIGNsYXNzTmFtZT0naWNvbi1iYXInPjwvc3Bhbj5cclxuICAgICAgICAgICAgICAgICAgICAgICAgPHNwYW4gY2xhc3NOYW1lPSdpY29uLWJhcic+PC9zcGFuPlxyXG4gICAgICAgICAgICAgICAgICAgIDwvYnV0dG9uPlxyXG4gICAgICAgICAgICAgICAgICAgIDxMaW5rIGNsYXNzTmFtZT0nbmF2YmFyLWJyYW5kJyB0bz17ICcvJyB9PkFzcE5ldENvcmVQbHVzUmVhY3Q8L0xpbms+XHJcbiAgICAgICAgICAgICAgICA8L2Rpdj5cclxuICAgICAgICAgICAgICAgIDxkaXYgY2xhc3NOYW1lPSdjbGVhcmZpeCc+PC9kaXY+XHJcbiAgICAgICAgICAgICAgICA8ZGl2IGNsYXNzTmFtZT0nbmF2YmFyLWNvbGxhcHNlIGNvbGxhcHNlJz5cclxuICAgICAgICAgICAgICAgICAgICA8dWwgY2xhc3NOYW1lPSduYXYgbmF2YmFyLW5hdic+XHJcbiAgICAgICAgICAgICAgICAgICAgICAgIDxsaT5cclxuICAgICAgICAgICAgICAgICAgICAgICAgICAgIDxOYXZMaW5rIGV4YWN0IHRvPXsgJy8nIH0gYWN0aXZlQ2xhc3NOYW1lPSdhY3RpdmUnPlxyXG4gICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIDxzcGFuIGNsYXNzTmFtZT0nZ2x5cGhpY29uIGdseXBoaWNvbi1ob21lJz48L3NwYW4+IEhvbWVcclxuICAgICAgICAgICAgICAgICAgICAgICAgICAgIDwvTmF2TGluaz5cclxuICAgICAgICAgICAgICAgICAgICAgICAgPC9saT5cclxuICAgICAgICAgICAgICAgICAgICAgICAgPGxpPlxyXG4gICAgICAgICAgICAgICAgICAgICAgICAgICAgPE5hdkxpbmsgdG89eyAnL2NvdW50ZXInIH0gYWN0aXZlQ2xhc3NOYW1lPSdhY3RpdmUnPlxyXG4gICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIDxzcGFuIGNsYXNzTmFtZT0nZ2x5cGhpY29uIGdseXBoaWNvbi1lZHVjYXRpb24nPjwvc3Bhbj4gQ291bnRlclxyXG4gICAgICAgICAgICAgICAgICAgICAgICAgICAgPC9OYXZMaW5rPlxyXG4gICAgICAgICAgICAgICAgICAgICAgICA8L2xpPlxyXG4gICAgICAgICAgICAgICAgICAgICAgICA8bGk+XHJcbiAgICAgICAgICAgICAgICAgICAgICAgICAgICA8TmF2TGluayB0bz17ICcvZmV0Y2hkYXRhJyB9IGFjdGl2ZUNsYXNzTmFtZT0nYWN0aXZlJz5cclxuICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICA8c3BhbiBjbGFzc05hbWU9J2dseXBoaWNvbiBnbHlwaGljb24tdGgtbGlzdCc+PC9zcGFuPiBGZXRjaCBkYXRhXHJcbiAgICAgICAgICAgICAgICAgICAgICAgICAgICA8L05hdkxpbms+XHJcbiAgICAgICAgICAgICAgICAgICAgICAgIDwvbGk+XHJcbiAgICAgICAgICAgICAgICAgICAgPC91bD5cclxuICAgICAgICAgICAgICAgIDwvZGl2PlxyXG4gICAgICAgICAgICA8L2Rpdj5cclxuICAgICAgICA8L2Rpdj47XHJcbiAgICB9XHJcbn1cclxuXG5cblxuLy8gV0VCUEFDSyBGT09URVIgLy9cbi8vIC4vQ2xpZW50QXBwL2NvbXBvbmVudHMvTmF2TWVudS50c3giLCJpbXBvcnQgKiBhcyBXZWF0aGVyRm9yZWNhc3RzIGZyb20gJy4vV2VhdGhlckZvcmVjYXN0cyc7XHJcbmltcG9ydCAqIGFzIENvdW50ZXIgZnJvbSAnLi9Db3VudGVyJztcclxuXHJcbi8vIFRoZSB0b3AtbGV2ZWwgc3RhdGUgb2JqZWN0XHJcbmV4cG9ydCBpbnRlcmZhY2UgQXBwbGljYXRpb25TdGF0ZSB7XHJcbiAgICBjb3VudGVyOiBDb3VudGVyLkNvdW50ZXJTdGF0ZTtcclxuICAgIHdlYXRoZXJGb3JlY2FzdHM6IFdlYXRoZXJGb3JlY2FzdHMuV2VhdGhlckZvcmVjYXN0c1N0YXRlO1xyXG59XHJcblxyXG4vLyBXaGVuZXZlciBhbiBhY3Rpb24gaXMgZGlzcGF0Y2hlZCwgUmVkdXggd2lsbCB1cGRhdGUgZWFjaCB0b3AtbGV2ZWwgYXBwbGljYXRpb24gc3RhdGUgcHJvcGVydHkgdXNpbmdcclxuLy8gdGhlIHJlZHVjZXIgd2l0aCB0aGUgbWF0Y2hpbmcgbmFtZS4gSXQncyBpbXBvcnRhbnQgdGhhdCB0aGUgbmFtZXMgbWF0Y2ggZXhhY3RseSwgYW5kIHRoYXQgdGhlIHJlZHVjZXJcclxuLy8gYWN0cyBvbiB0aGUgY29ycmVzcG9uZGluZyBBcHBsaWNhdGlvblN0YXRlIHByb3BlcnR5IHR5cGUuXHJcbmV4cG9ydCBjb25zdCByZWR1Y2VycyA9IHtcclxuICAgIGNvdW50ZXI6IENvdW50ZXIucmVkdWNlcixcclxuICAgIHdlYXRoZXJGb3JlY2FzdHM6IFdlYXRoZXJGb3JlY2FzdHMucmVkdWNlclxyXG59O1xyXG5cclxuLy8gVGhpcyB0eXBlIGNhbiBiZSB1c2VkIGFzIGEgaGludCBvbiBhY3Rpb24gY3JlYXRvcnMgc28gdGhhdCBpdHMgJ2Rpc3BhdGNoJyBhbmQgJ2dldFN0YXRlJyBwYXJhbXMgYXJlXHJcbi8vIGNvcnJlY3RseSB0eXBlZCB0byBtYXRjaCB5b3VyIHN0b3JlLlxyXG5leHBvcnQgaW50ZXJmYWNlIEFwcFRodW5rQWN0aW9uPFRBY3Rpb24+IHtcclxuICAgIChkaXNwYXRjaDogKGFjdGlvbjogVEFjdGlvbikgPT4gdm9pZCwgZ2V0U3RhdGU6ICgpID0+IEFwcGxpY2F0aW9uU3RhdGUpOiB2b2lkO1xyXG59XHJcblxuXG5cbi8vIFdFQlBBQ0sgRk9PVEVSIC8vXG4vLyAuL0NsaWVudEFwcC9zdG9yZS9pbmRleC50cyIsIm1vZHVsZS5leHBvcnRzID0gKF9fd2VicGFja19yZXF1aXJlX18oMCkpKDEzNSk7XG5cblxuLy8vLy8vLy8vLy8vLy8vLy8vXG4vLyBXRUJQQUNLIEZPT1RFUlxuLy8gZGVsZWdhdGVkIC4vbm9kZV9tb2R1bGVzL2RvbWFpbi10YXNrL2luZGV4LmpzIGZyb20gZGxsLXJlZmVyZW5jZSAuL3ZlbmRvclxuLy8gbW9kdWxlIGlkID0gMTlcbi8vIG1vZHVsZSBjaHVua3MgPSAwIiwibW9kdWxlLmV4cG9ydHMgPSAoX193ZWJwYWNrX3JlcXVpcmVfXygwKSkoMTQzKTtcblxuXG4vLy8vLy8vLy8vLy8vLy8vLy9cbi8vIFdFQlBBQ0sgRk9PVEVSXG4vLyBkZWxlZ2F0ZWQgLi9ub2RlX21vZHVsZXMvcmVkdXgtdGh1bmsvbGliL2luZGV4LmpzIGZyb20gZGxsLXJlZmVyZW5jZSAuL3ZlbmRvclxuLy8gbW9kdWxlIGlkID0gMjBcbi8vIG1vZHVsZSBjaHVua3MgPSAwIiwibW9kdWxlLmV4cG9ydHMgPSAoX193ZWJwYWNrX3JlcXVpcmVfXygwKSkoNzApO1xuXG5cbi8vLy8vLy8vLy8vLy8vLy8vL1xuLy8gV0VCUEFDSyBGT09URVJcbi8vIGRlbGVnYXRlZCAuL25vZGVfbW9kdWxlcy9yZWR1eC9saWIvaW5kZXguanMgZnJvbSBkbGwtcmVmZXJlbmNlIC4vdmVuZG9yXG4vLyBtb2R1bGUgaWQgPSAyMVxuLy8gbW9kdWxlIGNodW5rcyA9IDAiXSwic291cmNlUm9vdCI6IiJ9