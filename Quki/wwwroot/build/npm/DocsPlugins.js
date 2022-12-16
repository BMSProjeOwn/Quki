const Plugins = [
  // AdminLTE Dist
  {
    from: 'dist/css/',
    to  : 'docs/~/webQuki/css/'
  },
  {
    from: 'dist/js/',
    to  : 'docs/~/webQuki/js/'
  },
  // jQuery
  {
    from: 'node_modules/jquery/dist/',
    to  : 'docs/~/webQuki/plugins/jquery/'
  },
  // Popper
  {
    from: 'node_modules/popper.js/dist/',
    to  : 'docs/~/webQuki/plugins/popper/'
  },
  // Bootstrap
  {
    from: 'node_modules/bootstrap/dist/js/',
    to  : 'docs/~/webQuki/plugins/bootstrap/js/'
  },
  // Font Awesome
  {
    from: 'node_modules/@fortawesome/fontawesome-free/css/',
    to  : 'docs/~/webQuki/plugins/fontawesome-free/css/'
  },
  {
    from: 'node_modules/@fortawesome/fontawesome-free/webfonts/',
    to  : 'docs/~/webQuki/plugins/fontawesome-free/webfonts/'
  },
  // overlayScrollbars
  {
    from: 'node_modules/overlayscrollbars/js/',
    to  : 'docs/~/webQuki/plugins/overlayScrollbars/js/'
  },
  {
    from: 'node_modules/overlayscrollbars/css/',
    to  : 'docs/~/webQuki/plugins/overlayScrollbars/css/'
  }
]

module.exports = Plugins
