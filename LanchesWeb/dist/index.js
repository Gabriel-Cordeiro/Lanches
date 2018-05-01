'use strict';

var _server = require('./infraestrutura/server');

var _server2 = _interopRequireDefault(_server);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

_server2.default.listen(8090, function () {
    console.log('Running on port 8090');
});
//# sourceMappingURL=index.js.map