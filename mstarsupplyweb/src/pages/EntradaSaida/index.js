import { useEffect, useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { listaMercadorias, registraEntradaSaida } from "../../services/service";
import { Button, Container, Content, Input, Label, RadioField, Select } from "./styles";



export default function EntradaSaidaForm() {
  
  const navigate = useNavigate();
  
    useEffect(() => {
        carregaListaMercadorias();
    }, [])

    const [mercadorias, setMercadorias] = useState([]);
    const [selectedMerc, setSelectedMerc] = useState('');
    const [selectedTipo, setSelectedTipo] = useState('0');
    const [dataHora, setDataHora] = useState('');
    const [quantidade, setQuantidade] = useState('');
    const [local, setLocal] = useState('');


    function carregaListaMercadorias() {
        listaMercadorias()
          .then(response => response.json())
          .then(data => setMercadorias(data));
    }

    function handleRegistraEntradaSaida() {
      const registro = { 
        mercadoriaId: selectedMerc,
        dataHora: new Date(dataHora).toISOString(),
        tipo: parseInt(selectedTipo),
        quantidade: parseInt(quantidade),
        local: local
      }
      console.log(registro);

      registraEntradaSaida(registro)
        .then(res => res.ok ? navigate('/') : null);
    }

    return (
      <Container>
        <Content>

            <Link to={'/'}>voltar</Link>
            <p>Registrar entrada ou saida</p>

            <Label>Mercadoria</Label>
            <Select value={selectedMerc} onChange={e => setSelectedMerc(e.target.value)} >
            <option value="" disabled>selecione a mercadoria</option>
              {mercadorias.map(o => (
                <option key={o.id} value={o.id}>{o.nome}</option>
              ))}
            </Select>

            <Label>Local</Label>
            <Input type="text" onChange={e => setLocal(e.target.value)}></Input>

            <Label>Data do registro</Label>
            <Input type="datetime-local" onChange={e => setDataHora(e.target.value)}></Input>

            <Label>Quantidade</Label>
            <Input type="number" onChange={e => setQuantidade(e.target.value)}></Input>
            
            <Label>Tipo</Label>
            {/* <Select value={selectedTipo} onChange={e => setSelectedTipo(e.target.value)} >
            <option value=''>Tipo</option>
              <option value='0'>entrada</option>
              <option value='1'>saida</option>
            </Select> */}

            <RadioField>
              <input type="radio" id='entrada' value='0' 
                checked={selectedTipo === '0'}
                onChange={e => setSelectedTipo(e.target.value)}/>
              <label for='entrada'>Entrada</label>
            </RadioField>

            <RadioField>
              <input type="radio" id='saida' value="1"
                checked={selectedTipo === '1'}
                onChange={e => setSelectedTipo(e.target.value)}/>
              <label for='saida'>Saida</label>
            </RadioField>
            
            <Button onClick={() => handleRegistraEntradaSaida()}>registrar</Button>

        </Content>
      </Container>
    )
}