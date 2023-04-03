import { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { cadastraFabricante } from "../../services/service";
import { Button, Container, Content, Input, Label, Select } from "./styles";

export default function Fabricante() {
  
  const navigate = useNavigate();
  
    const [nome, setNome] = useState('');
    

    function handlecadastraFabricante() {
      if (validaCadastro()) {
        const fabricante = { nome }
        cadastraFabricante(fabricante).then(res => res.ok ? navigate('/') : null); 
      }
    }

    function validaCadastro() {
      if (isEmpty(nome)) {
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
            <p>Novo fabricante</p>

            <Label>Nome</Label>
            <Input type="text" onChange={e => setNome(e.target.value)}></Input>

            <Button onClick={() => handlecadastraFabricante()}>registrar</Button>

        </Content>
      </Container>
    )
}