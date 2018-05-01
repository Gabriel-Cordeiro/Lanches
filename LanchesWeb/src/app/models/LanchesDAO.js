import request from 'request'
import http from 'http'

function LanchesDAO(){

}

LanchesDAO.prototype.pegarTodosLanches = (cb) => {
    const host = 'http://localhost:52495/api/'
    const path = 'Lanches'
    return request(`${host}${path}`, (err, body) => {
        cb(err, body)
    })

}

LanchesDAO.prototype.pegarValosLanchesCustomizado = (dadosLanche, callback) => {
    let options = {
        hostname: 'localhost',
        port: 52495,
        path: '/api/Customizado',
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        }
    }

    let req = http.request(options, function (res) {
        res.setEncoding('utf8')
        res.on('data', function (body) {
            callback(body)
        })
    })
    req.on('error', function (e) {
        console.log('problem with request: ' + e.message)
    })
    req.write(dadosLanche)
    req.end()

}
module.exports = function () {
    return LanchesDAO
}
