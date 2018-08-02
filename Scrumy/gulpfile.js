/// <binding BeforeBuild='sass' Clean='sass' />
var gulp = require("gulp"),
    fs = require("fs"),
    less = require("gulp-less"),
    sass = require("gulp-sass");

// other content removed
var styleSrc = 'Styles/main.scss',
    styleDest = 'wwwroot/css';

gulp.task("sass", function () {
    return gulp.src(styleSrc)
        .pipe(sass())
        .pipe(gulp.dest(styleDest));
});