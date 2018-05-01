'use strict';

var _request = require('request');

var _request2 = _interopRequireDefault(_request);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

function IngredientesDAO() {}

IngredientesDAO.prototype.pegarTodosIngredientes = function (cb) {
    var host = 'http://localhost:52495/api/';
    var path = 'Ingredientes';

    return (0, _request2.default)('' + host + path, function (err, body) {
        cb(err, body);
    });
};

module.exports = function () {
    return IngredientesDAO;
};
//# sourceMappingURL=IngredientesDAO.js.map