angular.module('GrandTravelApp').factory('LessonService', ['$http', function ($http) {

    var _getLessons = function(){
        return $http.get('/api/lessons');
    };

    var _createLesson = function (lesson) {
        return $http.post('/api/lessons', lesson);
    };
    var _getById = function (id) {
        return $http.get('/api/lessons/' + id);
    };
    var _updateLesson = function (lesson) {
        return $http.put('/api/lessons/' + lesson.Id, lesson);
    };

    return {
        getLessons: _getLessons,
        createLesson: _createLesson,
        getById: _getById,
        updateLesson: _updateLesson
    };

    
}]);



