import { Component, OnInit, ɵCompiler_compileModuleSync__POST_R3__ } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  title = 'PetroConnect';
  constructor() { }

  ngOnInit(): void {
    console.log('home page loading');
  }

}
