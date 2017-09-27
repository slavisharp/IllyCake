var gulp = require("gulp"),
    fs = require("fs"),
    watch = require('gulp-watch'),
    less = require("gulp-less");

gulp.task("less", function () {
    return gulp.src('Styles/main.less')
        .pipe(less())
        .pipe(gulp.dest('wwwroot/css'));
});

gulp.task('watch', function () {
    gulp.watch('Styles/**/*.less', ['less']);
});