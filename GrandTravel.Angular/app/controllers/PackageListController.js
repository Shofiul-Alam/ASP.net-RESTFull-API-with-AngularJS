angular.module('grandTravelApp').controller('PackageListController', ['$scope', '$location', 'PackageService', 'FileUploader', 'Upload',

    function ($scope, $location, PackageService, FileUploader, Upload) {

        //Single File Upload
        $scope.Package = {};

        //MultiFile Upload Start Here
        var uploader = $scope.uploader = new FileUploader({
            url: 'api/packages/PhotoGallery'
        });

        $scope.addPackage = function (file) {
            Upload.upload({
                url: 'api/packages',
                data: { Package: $scope.Package, file: file }
            }).then(function (resp) {
                alert("Package was created");
                $scope.NewPackage = resp.data;
                uploader.formData.push({ packageId: $scope.NewPackage.PackageId });

            }, function (resp) {
                console.log('Error status: ' + resp.status);
            }, function (evt) {
                var progressPercentage = parseInt(100.0 * evt.loaded / evt.total);
                console.log('progress: ' + progressPercentage + '%');
            });
        };

        
  
        uploader.filters.push({
            name: 'customFilter',
            fn: function (item /*{File|FileLikeObject}*/, options) {
                return this.queue.length < 10;
            }
        });
        
       
        // CALLBACKS

        uploader.onWhenAddingFileFailed = function (item /*{File|FileLikeObject}*/, filter, options) {
            console.info('onWhenAddingFileFailed', item, filter, options);
        };
        uploader.onAfterAddingFile = function (fileItem) {
            console.info('onAfterAddingFile', fileItem);
        };
        uploader.onAfterAddingAll = function (addedFileItems) {
            console.info('onAfterAddingAll', addedFileItems);
        };
        uploader.onBeforeUploadItem = function (item) {
            console.info('onBeforeUploadItem', item);
        };
        uploader.onProgressItem = function (fileItem, progress) {
            console.info('onProgressItem', fileItem, progress);
        };
        uploader.onProgressAll = function (progress) {
            console.info('onProgressAll', progress);
        };
        uploader.onSuccessItem = function (fileItem, response, status, headers) {
            console.info('onSuccessItem', fileItem, response, status, headers);
        };
        uploader.onErrorItem = function (fileItem, response, status, headers) {
            console.info('onErrorItem', fileItem, response, status, headers);
        };
        uploader.onCancelItem = function (fileItem, response, status, headers) {
            console.info('onCancelItem', fileItem, response, status, headers);
        };
        uploader.onCompleteItem = function (fileItem, response, status, headers) {
           
            console.info('OnCompleteItem', fileItem, response, status, headers);
        };
        uploader.onCompleteAll = function () {
            console.info('onCompleteAll');
        };

        console.info('uploader', uploader);
        //MultiFileUpload End Here

        //Controller stuff goes here.


        PackageService.getLocations().then(function (response) {

            $scope.Locations = response.data;

        });


    }]);
