//criando o aplicativo Angular para SPA..
var app = angular.module('appAula',
    [
        'ngRoute', 
        'angularUtils.directives.dirPagination'
    ]);

//mapear os endereços de rotas do projeto..
//$routeProvider -> objeto do Angular-Route para 
//mapeamento de rotas (endereços de páginas)
app.config(function ($routeProvider) {

    $routeProvider
        .when(
            '/estoque/cadastro', //ROTA
            {
                templateUrl: '/App/Views/Estoque/Cadastro.html',
                controller: 'estoqueCadastroController'
            }
        )
        .when(
            '/estoque/consulta', //ROTA
            {
                templateUrl: '/App/Views/Estoque/Consulta.html',
                controller: 'estoqueConsultaController'
            }
        )
        .when(
            '/produto/cadastro', //ROTA
            {
                templateUrl: '/App/Views/Produto/Cadastro.html',
                controller: 'produtoCadastroController'
            }
        )
        .when(
            '/produto/consulta', //ROTA
            {
                templateUrl: '/App/Views/Produto/Consulta.html',
                controller: 'produtoConsultaController'
            }
        );
});

//configurar os endereços das rotas
app.config(function ($locationProvider) {
    $locationProvider.hashPrefix('');
});
