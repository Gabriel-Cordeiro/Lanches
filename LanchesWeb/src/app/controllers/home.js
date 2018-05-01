// const index = (app, req, res) => {
//     res.render('home/index')
// }

// export default index

module.exports.index = function (app, req, res) {
    res.render('home/index')
}