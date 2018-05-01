'use strict';

var lanchesProntos = function lanchesProntos(app, req, res) {

    var LanchesModel = new app.src.app.models.LanchesDAO();
    LanchesModel.pegarTodosLanches(function (err, cb) {
        var arrayLanches = JSON.parse(cb.body);
        res.render('lanches/lanchesProntos', { arrayLanches: arrayLanches });
    });
};

var lanchesCustomizados = function lanchesCustomizados(app, req, res) {
    var ingredientesModel = new app.src.models.IngredientesDAO();
    ingredientesModel.pegarTodosIngredientes(function (err, cb) {
        var arrayIngredientes = JSON.parse(cb.body);
        console.log(arrayIngredientes);
    });
    res.render('lanches/LanchesCustomizados');
};

module.exports = {
    lanchesProntos: lanchesProntos,
    lanchesCustomizados: lanchesCustomizados

};
//# sourceMappingURL=lanches.js.map