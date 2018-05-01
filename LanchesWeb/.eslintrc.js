module.exports = {
    "env": {
      "node": true,
      "mocha": true,
      "es6": true
    },
    "extends": ["eslint:recommended"],
    "parser": "babel-eslint",
    "parserOptions": {
      "sourceType": "module"
    },
    "rules": {
      "no-console": ["warn"],
      "indent": ["error", 4],
      "quotes": ["error", "single"],
      "semi": ["error", "never"],
      "no-alert": "error",
      "no-caller": "error",
      "no-empty-function": "error",
      "no-else-return": "error",
      "no-eval": "error",
      "no-extend-native": "error",
      //"complexity": ["error", 6],
      "no-new-wrappers": "error",
      "no-script-url": "error",
      "no-throw-literal": "error",
      "no-void": "error",
      "no-with": "error",
      "prefer-promise-reject-errors": "error",
      "require-await": "error",
      "no-trailing-spaces": "error",
      "arrow-parens": "error",
      "arrow-spacing": "error",
      "no-duplicate-imports": "error",
      "no-useless-constructor": "error",
      "no-var": "error",
      "prefer-rest-params": "error",
    }
  };