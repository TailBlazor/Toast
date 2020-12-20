//tailwindcss.config.js
const colors = require('tailwindcss/colors');

module.exports = {
  purge: [],
  darkMode: 'media', // or 'media' or 'class'
  theme: {
    colors: {
      transparent: 'transparent',
      current: 'currentColor',
      black: colors.black,
      gray: colors.coolGray,
      blueGray: colors.blueGray,
      warmGray: colors.warmGray,
      trueGray: colors.trueGray,
      white: colors.white,
      red: colors.red,
      orange: colors.orange,
      amber: colors.amber,
      yellow: colors.yellow,
      cyan: colors.cyan,
      emerald: colors.emerald,
      fuchsia: colors.fuchsia,
      lightBlue: colors.lightBlue,
      teal: colors.teal,
      purple: colors.purple,
      green: colors.emerald,
      blue: colors.blue,
      indigo: colors.indigo,
      violet: colors.violet,
      pink: colors.pink,
    },
    extend: {},
  },
  variants: {
    extend: {},
  },
  plugins: [
  ]
}