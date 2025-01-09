function PruebaPuntoNETStatic() {
    DotNet.invokeMethodAsync("BlazorPeliculas.Client", "ObtenetCurrentCount")
        .then(resultado => {
            console.log('conteo desde javascript', resultado);
        })
}

function PruebaPuntoNetInstancia(dotnetHelper) {
    dotnetHelper.invokeMethodAsync("IncrementCount");
}