import { Component, OnDestroy, OnInit } from '@angular/core';
import { ConfigurationServicService } from './services/configuration-servic.service';
import { Configuration } from './model/configuration';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'DECommerceFE';


  constructor(private ConfigurationsService : ConfigurationServicService  ){}


  ngOnInit(): void {
    this.ConfigurationsService.initialize();
      console.log(this.ConfigurationsService.initialize())
  }
}
