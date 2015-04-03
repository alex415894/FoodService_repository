function dishController($scope, $http) {
    $scope.loading = true;
    $scope.addMode = false;

    //Used to display the data 
    $http.get('/api/Dishes/').success(function (data) {
        $scope.Dishes = data;
        $scope.loading = false;
    })
    .error(function () {
        $scope.error = "An Error has occured while loading posts!";
        $scope.loading = false;
    });

    $scope.toggleEdit = function () {
        this.Dish.editMode = !this.Dish.editMode;
    };
    $scope.toggleAdd = function () {
        $scope.addMode = !$scope.addMode;
    };

    //Used to save a record after edit 
    $scope.save = function () {
        alert("Edit");
        $scope.loading = true;
        var frien = this.Dish;
        alert(emp);
        $http.put('/api/Dishes/', frien).success(function (data) {
            alert("Saved Successfully!!");
            emp.editMode = false;
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while Saving Dish! " + data;
            $scope.loading = false;

        });
    };

    //Used to add a new record 
    $scope.add = function () {
        $scope.loading = true;
        $http.post('/api/Dishes/', this.newDish).success(function (data) {
            alert("Added Successfully!!");
            $scope.addMode = false;
            $scope.Dishes.push(data);
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while Adding Dish! " + data;
            $scope.loading = false;

        });
    };

    //Used to edit a record 
    $scope.deleteDish = function () {
        $scope.loading = true;
        var Dishid = this.Dish.DishId;
        $http.delete('/api/Dishes/' + Dishid).success(function (data) {
            alert("Deleted Successfully!!");
            $.each($scope.Dishes, function (i) {
                if ($scope.Dishes[i].DishId === Dishid) {
                    $scope.Dishes.splice(i, 1);
                    return false;
                }
            });
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while Saving Dish! " + data;
            $scope.loading = false;

        });
    };

}