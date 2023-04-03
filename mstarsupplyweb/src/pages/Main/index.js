import { useEffect, useState } from 'react';
import { Button, Container, Content, Control, Table, Tbody } from './styles'
import { listaEntradasSaida, listaEntradasSaidaPorMercadoria, listaMercadorias } from '../../services/service';
import { useNavigate } from 'react-router-dom';

export default function Main() {

  const navigate = useNavigate();

  const [mercadorias, setMercadorias] = useState([]);
  const [entradasSaidas, setEntradasSaidas] = useState([]);
  const [selectedMerc, setSelectedMerc] = useState('');
  const [selectedTipoES, setSelectedTipoES] = useState('');

  useEffect(() => {
    carregaListaEntradaSaida();
    carregaListaMercadorias();
  }, [])

  function formatDate(date) {
    return new Date(date).toLocaleTimeString("pt-BR", { month: "short", day: "2-digit", year: "numeric" });
  }

  function buscaEntradaSaidaPorMercadoria() {
    if (selectedMerc && selectedTipoES) {
      listaEntradasSaidaPorMercadoria(selectedMerc, selectedTipoES)
        .then(response => response.json())
        .then(data => setEntradasSaidas(data));
    } else {
      alert('os campos do filtro estão vazios!');
    }
  }

  function limparFiltro() {
    carregaListaEntradaSaida();
    setSelectedMerc('');
    setSelectedTipoES('');
  }

  function carregaListaMercadorias() {
    listaMercadorias()
      .then(response => response.json())
      .then(data => setMercadorias(data));
  }

  function carregaListaEntradaSaida() {
    listaEntradasSaida()
      .then(response => response.json())
      .then(data => setEntradasSaidas(data));
  }

  return (
    <Container>
      <Content>
          <Control>
            <Button onClick={() => navigate('/entrada-saida')}>nova entrada/saída</Button>
            <Button onClick={() => navigate('/mercadoria')} >nova mercadoria</Button>
            <Button>adicionar fabricante</Button>
          </Control>
          
          <div>
            <p>filtar por mercadoria: </p>
            <select value={selectedMerc} onChange={e => setSelectedMerc(e.target.value)} >
              <option value=''></option>
              {mercadorias.map(o => (
                <option key={o.id} value={o.id}>{o.nome}</option>
              ))}
            </select>
            <select value={selectedTipoES} onChange={e => setSelectedTipoES(e.target.value)} >
            <option value=''></option>
              <option value='0'>entrada</option>
              <option value='1'>saida</option>
            </select>
            <button onClick={() => buscaEntradaSaidaPorMercadoria()}>buscar</button>
            <button onClick={() => limparFiltro()}>limpar</button>
          </div>

          <Table>
            <thead>
              <tr>
                <th>Nome Mercadoria</th>
                <th>Descrição</th>
                <th>quantidade</th>
                <th>tipo</th>
                <th>local</th>
                <th>data hora</th>
              </tr>
            </thead>
            <Tbody>
            {entradasSaidas.map((es) => (
              <tr key={es.id}>
                <td>{es.mercadoria.nome}</td>
                <td>{es.mercadoria.descricao}</td>
                <td>{es.quantidade}</td>
                <td>{es.tipo === 0 ? 'entrada' : 'saida'}</td>
                <td>{es.local}</td>
                <td>{formatDate(es.dataHora)}</td>
              </tr>
            ))}
            </Tbody>
          </Table>
      </Content>
    </Container>
  )
}