import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { IUsuario } from '../../interfaces/IUsuario';
import { UsuarioService } from '../../services/usuario.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  formLogin!: FormGroup;
  constructor(private formBuilder: FormBuilder,
              private usuarioService: UsuarioService,
              private snackBar: MatSnackBar) { }
  ngOnInit(): void {
    this.criarForm();
  }
  criarForm(){
    this.formLogin = this.formBuilder.group({
      Email: ['', [Validators.required, Validators.email]],
      Password: ['', [Validators.required]]
    });
  }
  logar(){
    if(this.formLogin.invalid) return;
    var usuario = this.formLogin.getRawValue() as IUsuario;
    this.usuarioService.logar(usuario).subscribe(data => console.log(data),
    error => this.snackBar.open('Falha na autenticação', 'Usuário ou senha incorretos.', {
      duration: 3000}))
   }
}
