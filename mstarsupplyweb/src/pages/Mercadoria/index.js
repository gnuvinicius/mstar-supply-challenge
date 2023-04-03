import { useEffect, useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { cadastraMercadoria, listaFabricantes } from "../../services/service";
import { Button, Container, Content, Input, Label, Select } from "./styles";



export default function Mercadoria() {
  
  const navigate = useNavigate();
  
    useEffect(() => {
        carregaListaFabricantes();
    }, [])

    const [fabricantes, setFabricantes] = useState([]);
    const [selectedFabric, setSelectedFabric] = useState('');
    const [nome, setNome] = useState('');
    const [descricao, setDescricao] = useState('');
    const [tipo, setTipo] = useState('');
    const [numeroDeRegistro, setNumeroDeRegistro] = useState('');

    function carregaListaFabricantes() {
        listaFabricantes()
          .then(response => response.json())
          .then(data => setFabricantes(data));
    }

    function handlecadastraMercadoria() {
      if (validaCadastro()) {
        const mercadoria = { 
          fabricanteId: selectedFabric,
          nome: nome,
          descricao: descricao,
          tipo: tipo,
          numeroDeRegistro: numeroDeRegistro
        }
  
        cadastraMercadoria(mercadoria).then(res => res.ok ? navigate('/') : null); 
      }

    }

    function validaCadastro() {
      if (isEmpty(selectedFabric) || isEmpty(nome) || isEmpty(descricao) ) {
        alert('existem campos obrigatorios não preenchidos!')
        return false;
      }
      return true;
    }

    function isEmpty(str) {
      return !str.trim().length;
  }

    return (
      <Container>
        <Content>

            <Link to={'/'}>voltar</Link>
            <p>Nova Mercadoria</p>

            <Label>Nome</Label>
            <Input type="text" onChange={e => setNome(e.target.value)}></Input>

            <Label>Descrição</Label>
            <Input type="text" onChange={e => setDescricao(e.target.value)}></Input>

            <Label>N. de Registro</Label>
            <Input type="text" onChange={e => setNumeroDeRegistro(e.target.value)}></Input>

            <Label>Tipo</Label>
            <Input type="text" onChange={e => setTipo(e.target.value)}></Input>

            <Label>Mercadoria</Label>
            <Select value={selectedFabric} onChange={e => setSelectedFabric(e.target.value)} >
            <option value="" disabled>selecione o fabricante</option>
              {fabricantes.map(o => (
                <option key={o.id} value={o.id}>{o.nome}</option>
              ))}
            </Select>
            
            <Button onClick={() => handlecadastraMercadoria()}>registrar</Button>

        </Content>
      </Container>
    )
}