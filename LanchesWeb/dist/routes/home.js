'use strict';

module.exports = function (app) {
    app.get('/', function (req, res) {
        app.src.app.controllers.home.index(app, req, res);
    });
};
//# sourceMappingURL=home.js.map