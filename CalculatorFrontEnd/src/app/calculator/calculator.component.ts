import { Component, OnInit } from '@angular/core';
import { SubmitCalculationVM } from '../models/calculatorInput';
import { CalculatorService } from '../services/calculator.service';

@Component({
  selector: 'app-calculator',
  templateUrl: './calculator.component.html',
  styleUrls: ['./calculator.component.scss']
})
export class CalculatorComponent implements OnInit {

  public Calculation = new SubmitCalculationVM();
  public Inputs: string = "";
  public NumbersDisabled: boolean = false;
  public OperatorsDisabled: boolean = true;
  public EqualsDisabled: boolean = true;

  constructor(private calcService: CalculatorService) {
  }

  ngOnInit(): void {
  }

  characterPush(character: string){
    if(this.Calculation.FirstNumber == ""){
      this.Calculation.FirstNumber = character;
      this.NumbersDisabled = true;
      this.OperatorsDisabled = false;
    } else if(this.Calculation.Operator == ""){
      this.Calculation.Operator = character;
      this.NumbersDisabled = false;
      this.OperatorsDisabled = true;
    } else if(this.Calculation.SecondNumber == ""){
      this.Calculation.SecondNumber = character;
      this.NumbersDisabled = true;
      this.OperatorsDisabled = true;
      this.EqualsDisabled = false;
    }
    this.Inputs += character;
  }

  ClearInput(){
    this.NumbersDisabled = false;
    this.OperatorsDisabled = true;
    this.EqualsDisabled = true;
    this.Inputs = "";
    this.Calculation = new SubmitCalculationVM();
  }

  Calculate() {
    this.calcService.Calculate(this.Calculation)
    .subscribe(response => {
      this.Inputs = response;
      this.EqualsDisabled = true;
    });
  }

}

