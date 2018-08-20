/// <binding BeforeBuild='sass' Clean='sass' />
var gulp = require("gulp"),
    fs = require("fs"),
    less = require("gulp-less"),
    sass = require("gulp-sass");

var mainSrc = ['Styles/*.scss', '!Styles/Variables.scss', '!Styles/Mixins.scss'],
    styleDest = 'wwwroot/css';

gulp.task("sass", function () {
    return gulp.src(mainSrc)
        .pipe(sass())
        .pipe(gulp.dest(styleDest));
});