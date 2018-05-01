const app = require('./infraestrutura/server')

app.listen(8090, () => {
    console.log('Running on port 8090')
})