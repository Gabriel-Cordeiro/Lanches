'use strict';

module.exports = function (app) {
    app.get('/prontos', function (req, res) {
        app.src.app.controllers.lanches.lanchesProntos(app, req, res);
    });

    app.get('/customizados', function (req, res) {
        app.src.app.controllers.lanches.lanchesCustomizados(app, req, res);
    });
};
//# sourceMappingURL=lanches.js.map