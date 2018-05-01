const request = require('request')

function IngredientesDAO() {
}

IngredientesDAO.prototype.pegarTodosIngredientes = (cb) => {
    const host = 'http://localhost:52495/api/'
    const path = 'Ingredientes'

    return request(`${host}${path}`, (err, body) => {
        cb(err, body)
    })


}

module.exports = function () {
    return IngredientesDAO
}