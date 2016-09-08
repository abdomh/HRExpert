/// <binding BeforeBuild='rebuild' />
// Copyright � 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

var gulp = require("gulp"),
  autoprefixer = require("gulp-autoprefixer"),
  concat = require("gulp-concat"),
  del = require("del"),
  minifyCss = require("gulp-minify-css"),
  rename = require("gulp-rename"),
  runSequence = require("run-sequence"),
  sass = require("gulp-sass"),
  tsc = require("gulp-tsc"),
  uglify = require("gulp-uglify");

var paths = {
  backend: {
    scss: {
      src: [
        "areas/backend/styles/*.scss"
      ],
      dest: "wwwroot/areas/backend/css"
    },
    ts: {
      src: [
        "areas/backend/scripts/*.ts"
      ],
      dest: "wwwroot/areas/backend/js"
    }
  }
}

gulp.task(
  "rebuild",
  function (cb) {
    runSequence(
      "clean",
      "build",
      "minify",
      "delete-unminified",
      "rename-temp-minified",
      "delete-temp-minified",
      cb
    );
  }
);

gulp.task(
  "clean", function (cb) {
    runSequence(["backend:clean-scss", "backend:clean-ts"], cb);
  }
);

gulp.task(
  "backend:clean-scss", function () {
    return del(paths.backend.scss.dest + "/*");
  }
);

gulp.task(
  "backend:clean-ts", function () {
    return del(paths.backend.ts.dest + "/*");
  }
);

gulp.task(
  "build", function (cb) {
    runSequence("backend:build-scss", "backend:build-ts", cb);
  }
);

gulp.task(
  "backend:build-scss", function (cb) {
    return gulp.src(paths.backend.scss.src)
      .pipe(sass())
      .pipe(gulp.dest(paths.backend.scss.dest));
  }
);

gulp.task(
  "backend:build-ts", function (cb) {
    return gulp.src(paths.backend.ts.src)
      .pipe(tsc())
      .pipe(gulp.dest(paths.backend.ts.dest));
  }
);

gulp.task(
  "minify", function (cb) {
    runSequence("backend:minify-css", "backend:minify-js", cb);
  }
);

gulp.task(
  "backend:minify-css", function (cb) {
    return gulp.src(paths.backend.scss.dest + "/*.css")
      .pipe(minifyCss())
      .pipe(autoprefixer())
      .pipe(concat("platformus.barebone.min.css.temp"))
      .pipe(gulp.dest(paths.backend.scss.dest));
  }
);

gulp.task(
  "backend:minify-js", function (cb) {
    return gulp.src(
        [
          paths.backend.ts.dest + "/platformus.js",
          paths.backend.ts.dest + "/platformus.controls.behaviors.checkbox.js",
          paths.backend.ts.dest + "/platformus.controls.behaviors.dropdownlist.js",
          paths.backend.ts.dest + "/platformus.controls.behaviors.grid.js",
          paths.backend.ts.dest + "/platformus.controls.behaviors.imageuploader.js",
          paths.backend.ts.dest + "/platformus.controls.behaviors.tabs.js",
          paths.backend.ts.dest + "/platformus.controls.behaviors.uploader.js",
          paths.backend.ts.dest + "/platformus.controls.behaviors.js",
          paths.backend.ts.dest + "/platformus.controls.extenders.js",
          paths.backend.ts.dest + "/platformus.controls.extenders.maxlengthindicator.js",
          paths.backend.ts.dest + "/platformus.controls.extenders.tabstop.js",
          paths.backend.ts.dest + "/platformus.overlays.js",
          paths.backend.ts.dest + "/platformus.overlays.deleteform.js",
          paths.backend.ts.dest + "/platformus.ui.js",
          paths.backend.ts.dest + "/platformus.application.js",
          paths.backend.ts.dest + "/*.js"
        ]
      )
      .pipe(uglify())
      .pipe(concat("platformus.barebone.min.js.temp"))
      .pipe(gulp.dest(paths.backend.ts.dest));
  }
);

gulp.task(
  "delete-unminified", function (cb) {
    runSequence("backend:delete-unminified-css", "backend:delete-unminified-js", cb);
  }
);

gulp.task(
  "backend:delete-unminified-css", function () {
    return del(paths.backend.scss.dest + "/*.css");
  }
);

gulp.task(
  "backend:delete-unminified-js", function () {
    return del(paths.backend.ts.dest + "/*.js");
  }
);

gulp.task(
  "rename-temp-minified", function (cb) {
    runSequence("backend:rename-temp-minified-css", "backend:rename-temp-minified-js", cb);
  }
);

gulp.task(
  "backend:rename-temp-minified-css", function (cb) {
    return gulp.src(paths.backend.scss.dest + "/platformus.barebone.min.css.temp")
      .pipe(rename("platformus.barebone.min.css"))
      .pipe(gulp.dest(paths.backend.scss.dest));
  }
);

gulp.task(
  "backend:rename-temp-minified-js", function (cb) {
    return gulp.src(paths.backend.ts.dest + "/platformus.barebone.min.js.temp")
      .pipe(rename("platformus.barebone.min.js"))
      .pipe(gulp.dest(paths.backend.ts.dest));
  }
);

gulp.task(
  "delete-temp-minified", function (cb) {
    runSequence("backend:delete-temp-minified-css", "backend:delete-temp-minified-js", cb);
  }
);

gulp.task(
  "backend:delete-temp-minified-css", function () {
    return del(paths.backend.scss.dest + "/*.temp");
  }
);

gulp.task(
  "backend:delete-temp-minified-js", function () {
    return del(paths.backend.ts.dest + "/*.temp");
  }
);