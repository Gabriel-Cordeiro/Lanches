'use strict';

var _slicedToArray = function () { function sliceIterator(arr, i) { var _arr = []; var _n = true; var _d = false; var _e = undefined; try { for (var _i = arr[Symbol.iterator](), _s; !(_n = (_s = _i.next()).done); _n = true) { _arr.push(_s.value); if (i && _arr.length === i) break; } } catch (err) { _d = true; _e = err; } finally { try { if (!_n && _i["return"]) _i["return"](); } finally { if (_d) throw _e; } } return _arr; } return function (arr, i) { if (Array.isArray(arr)) { return arr; } else if (Symbol.iterator in Object(arr)) { return sliceIterator(arr, i); } else { throw new TypeError("Invalid attempt to destructure non-iterable instance"); } }; }();

var lanchesProntos = function lanchesProntos(app, req, res) {

    var LanchesModel = new app.src.app.models.LanchesDAO();
    LanchesModel.pegarTodosLanches(function (err, cb) {
        var arrayLanches = JSON.parse(cb.body);
        res.render('lanches/lanchesProntos', { arrayLanches: arrayLanches });
    });
};

var lanchesCustomizados = function lanchesCustomizados(app, req, res) {
    var ingredientesModel = new app.src.app.models.IngredientesDAO();
    ingredientesModel.pegarTodosIngredientes(function (err, cb) {
        var arrayIngredientes = JSON.parse(cb.body);
        res.render('lanches/LanchesCustomizados', { arrayIngredientes: arrayIngredientes });
    });
};

var CalcularlancheCustomizado = function CalcularlancheCustomizado(app, req, res) {
    var result = [];

    Object.entries(req.body).forEach(function (_ref) {
        var _ref2 = _slicedToArray(_ref, 2),
            key = _ref2[0],
            value = _ref2[1];

        var val = parseInt(value);
        if (val > 0) {
            Array.prototype.forEach.call(Array(val).fill(), function () {
                result.push({ NomeIngrediente: key });
            });
        }
    });

    var jsonResult = JSON.stringify(result);
    var lanchesModel = new app.src.app.models.LanchesDAO();

    lanchesModel.pegarValoresLanchesCustomizado(jsonResult, function (dadosLancheCustomizado) {
        var arrayLanche = JSON.parse(dadosLancheCustomizado);
        res.render('lanches/LancheCustomizadoVenda', { arrayLanche: arrayLanche });
    });
};

module.exports = {
    lanchesProntos: lanchesProntos,
    lanchesCustomizados: lanchesCustomizados,
    CalcularlancheCustomizado: CalcularlancheCustomizado
};
//# sourceMappingURL=lanches.js.map