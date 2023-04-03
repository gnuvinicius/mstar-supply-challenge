const API_PATH = `${process.env.REACT_APP_API_KEY}/Mercadoria`

const headers = new Headers();
headers.append('Accept', 'application/json')
headers.append('Content-type', 'application/json')


export function listaMercadorias() {
    return fetch(`${API_PATH}/ListaMercadorias`, { method: 'GET', headers: headers })
}

export function listaEntradasSaida() {
    return fetch(`${API_PATH}/ListaEntradasSaida`, { method: 'GET', headers: headers })
}

export function listaEntradasSaidaPorMercadoria(mercadoriaId, tipo) {
    return fetch(`${API_PATH}/ListaEntradasSaidaPorMercadoria?mercadoriaId=${mercadoriaId}&tipo=${tipo}`, { method: 'GET', headers: headers })
}

export function listaFabricantes() {
    return fetch(`${API_PATH}/ListaFabricantes`, { method: 'GET', headers: headers })
}

export function registraEntradaSaida(registro) {
    return fetch(`${API_PATH}/RegistraEntradaSaidaMercadoria`, { method: 'POST', body: JSON.stringify(registro), headers: headers })
}

export function cadastraMercadoria(mercadoria) {
    return fetch(`${API_PATH}/CadastraMercadoria`, { method: 'POST', body: JSON.stringify(mercadoria), headers: headers })
}