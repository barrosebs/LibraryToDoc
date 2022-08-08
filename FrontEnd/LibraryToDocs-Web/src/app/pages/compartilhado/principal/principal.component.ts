import { UsuarioService } from './../../../services/usuario.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-principal',
  templateUrl: './principal.component.html',
  styleUrls: ['./principal.component.css']
})
export class PrincipalComponent implements OnInit {
  constructor(private usuarioService: UsuarioService) { }
  ngOnInit(): void {
  }
  deslogar(){
    this.usuarioService.deslogar();
  }

}
