'use strict';

var _request = require('request');

var _request2 = _interopRequireDefault(_request);

var _http = require('http');

var _http2 = _interopRequireDefault(_http);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

function LanchesDAO() {}

LanchesDAO.prototype.pegarTodosLanches = function (cb) {
    var host = 'http://localhost:52495/api/';
    var path = 'Lanches';
    return (0, _request2.default)('' + host + path, function (err, body) {
        cb(err, body);
    });
};

LanchesDAO.prototype.pegarValoresLanchesCustomizado = function (dadosLanche, callback) {
    var options = {
        hostname: 'localhost',
        port: 52495,
        path: '/api/Customizado',
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        }
    };

    var req = _http2.default.request(options, function (res) {
        res.setEncoding('utf8');
        res.on('data', function (body) {
            callback(body);
        });
    });
    req.on('error', function (e) {
        console.log('problem with request: ' + e.message);
    });
    req.write(dadosLanche);
    req.end();
};
module.exports = function () {
    return LanchesDAO;
};
//# sourceMappingURL=LanchesDAO.js.map