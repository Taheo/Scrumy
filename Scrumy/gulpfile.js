/// <binding BeforeBuild='sass' Clean='sass' />
var gulp = require("gulp"),
    fs = require("fs"),
    less = require("gulp-less"),
    sass = require("gulp-sass");

// other content removed
var mainSrc = ['Styles/main.scss', 'Styles/footer.scss', 'Styles/homepage.scss', 'Styles/register.scss', 'Styles/login.scss'],
    styleDest = 'wwwroot/css';

gulp.task("sass", function () {
    return gulp.src(mainSrc)
        .pipe(sass())
        .pipe(gulp.dest(styleDest));
});