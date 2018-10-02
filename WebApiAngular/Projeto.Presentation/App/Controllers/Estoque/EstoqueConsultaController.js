app.controller('estoqueConsultaController',
    function ($scope, $estoqueService) {

        //criando uma função para executar o serviço
        //de consulta de estoques na API e retornar os dados..
        $scope.consultar = function () {

            //executar o serviço de consulta na API..
            $estoqueService.consultar()
                .then(function (result) { //promisse
                    //guardar a lista de estoques..
                    $scope.estoques = result.data;
                })
                .catch(function (e) { //promisse
                    $scope.mensagem = e.data;
                })
                .finally(function () {

                });
        };

    });