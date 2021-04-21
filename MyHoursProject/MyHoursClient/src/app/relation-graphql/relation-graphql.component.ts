import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Apollo } from 'apollo-angular';
import { CREATE_RELATION, DELETE_RELATION, EDIT_RELATION } from './mutations';
import { GETPROJECTS_QUERY, GETRELATION_QUERY, HPRO_QUERY, HUSE_QUERY, RELATION_QUERY } from './queries';
import html2canvas from 'html2canvas';
import { jsPDF } from 'jspdf';
import * as XLSX from 'xlsx';
import { Chart } from 'node_modules/chart.js';

@Component({
  selector: 'app-relation-graphql',
  templateUrl: './relation-graphql.component.html',
  styleUrls: ['./relation-graphql.component.scss']
})
export class RelationGraphqlComponent implements OnInit {
  public userId = null;
  public relations: any;
  public projects: any;
  public user: any;
  public project: any;
  public currentRelation: any;
  public dashboard = '';
  public date = null;
  public timetemp = null;
  public time = null;

  public totalPro= null;
  public totalUser= null;

  public relationid = null;
  public proIdTemp = null;

  public isTrackin = false
  public isReportProject = false;
  public isReportUser = false;

  public isFormVisible = false;


  constructor(private route: ActivatedRoute, private apollo: Apollo) {
    this.relations = [];
    this.projects = [];
  }

  ngOnInit(): void {
    this.pieChart()
    let id = this.route.snapshot.params.id;
    this.userId = id;
    this.filter();
    this.getProjects();
    console.log(id);
  }
  
  pieChart(){
    var myChart = new Chart("myChart", {
      type: 'pie',
      data: {
          labels: ['Projects', 'Users'],
          datasets: [{
              label: '# of Votes',
              data: [this.totalPro, this.totalUser],
              backgroundColor: [
                  'rgba(255, 99, 132, 0.2)',
                  'rgba(54, 162, 235, 0.2)',
              ],
              borderColor: [
                  'rgba(255, 99, 132, 1)',
                  'rgba(54, 162, 235, 1)',
              ],
              borderWidth: 1
          }]
      },
      options: {
          scales: {
              y: {
                  beginAtZero: true
              }
          }
      }
  });
  }
  reset() {
    this.currentRelation = {
      dashboard: '',
      date: '',
      time: ''
    };
    this.isFormVisible = false;
    this.timetemp = 0;
  }

  logout() {
    window.location.href = "http://localhost:4200/login"
  }
  filter() {
    this.apollo.watchQuery({
      query: RELATION_QUERY,
      fetchPolicy: 'network-only',
      variables: {
        userid: this.userId === '' ? null : this.userId,
      }
    }).valueChanges.subscribe(result => {
      var res: any;
      res = result;
      this.relations = res.data.relation;
      console.log(this.relations);
      this.reset();
    });
  }
  getProjects() {
    this.apollo.watchQuery({
      query: GETPROJECTS_QUERY,
      fetchPolicy: 'network-only',
      variables: {
        userid: this.userId === '' ? null : this.userId,
      }
    }).valueChanges.subscribe(result => {
      var res: any;
      res = result;
      this.projects = res.data.getprojects;
      console.log(this.projects);
    });
  }
  delete(id: number) {
    this.apollo.mutate({
      mutation: DELETE_RELATION,
      variables: {
        id: id
      }
    }).subscribe(() => {
      this.filter();
    });
  }
  tracking() {
    var hour = parseFloat(this.timetemp) + parseFloat(this.time);
    let relation = {
      dashboard: this.dashboard,
      time: hour,
      userId: this.userId,
      projectId: this.proIdTemp
    };
    this.apollo.mutate({
      mutation: EDIT_RELATION,
      variables: {
        id: this.relationid,
        relation: relation
      }
    }).subscribe(() => {
      alert("Add succesfully");
      window.location.href = "http://localhost:4200/home/" + this.userId;
    });
  }
  tracktime(id: number) {
    this.isTrackin = true;
    this.proIdTemp = id;
    this.apollo.watchQuery({
      query: GETRELATION_QUERY,
      fetchPolicy: 'network-only',
      variables: {
        userid: this.userId,
        projectid: id
      }
    }).valueChanges.subscribe(result => {
      var res: any;
      res = result;
      this.relationid = res.data.getrelation;
      this.timetemp = res.data.gettime;
      console.log(this.relationid);
      console.log(this.timetemp);
    });
  }

  proReport(id:number) {
    this.isReportProject = true;
    this.isReportUser = false;
    this.apollo.watchQuery({
      query: HPRO_QUERY,
      fetchPolicy: 'network-only',
      variables: {
        projectid: id
      }
    }).valueChanges.subscribe(result => {
      var res: any;
      res = result;
      this.totalPro = res.data.sumPro;
      console.log(this.totalPro);
    });

  }
  excelproReport(){
    /* table id is passed over here */   
    let element = document.getElementById('projectReport'); 
    const ws: XLSX.WorkSheet =XLSX.utils.table_to_sheet(element);

    /* generate workbook and add the worksheet */
    const wb: XLSX.WorkBook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Sheet1');

    /* save to file */
    XLSX.writeFile(wb, "ExcelSheetprojectReport.xlsx");
  }
  pdfproReport(){

    let data = document.getElementById("printProjectReport")
    this.generatePDF(data);
    
  }
  generatePDF(htmlContent){
    html2canvas(htmlContent).then(canvas => {
      let imgWidth = 290;
      let imgHeigth = (canvas.height * imgWidth / canvas.width)
      const contentDataURL = canvas.toDataURL('image/png')
      let pdf = new jsPDF('l', 'mm', 'a4');
      var position = 10;
      pdf.addImage(contentDataURL, 'PNG', 0 ,position,imgWidth, imgHeigth);
      pdf.save("ProjectHoursReport.pdf");
    })
  }
  userReport() {
    this.isReportUser = true;
    this.isReportProject = false;
    this.apollo.watchQuery({
      query: HUSE_QUERY,
      fetchPolicy: 'network-only',
      variables: {
        userid: this.userId
      }
    }).valueChanges.subscribe(result => {
      var res: any;
      res = result;
      this.totalUser = res.data.sumUser;
      console.log(this.totalUser);
    });
  }
  exceluserReport(){
    /* table id is passed over here */   
    let element = document.getElementById('userReport'); 
    const ws: XLSX.WorkSheet =XLSX.utils.table_to_sheet(element);

    /* generate workbook and add the worksheet */
    const wb: XLSX.WorkBook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Sheet1');

    /* save to file */
    XLSX.writeFile(wb, "ExcelSheetuserReport.xlsx");
  }
  pdfuserReport(){
    let data = document.getElementById("printUserReport")
    this.generateuserPDF(data);
  }
  generateuserPDF(htmlContent){
    html2canvas(htmlContent).then(canvas => {
      let imgWidth = 290;
      let imgHeigth = (canvas.height * imgWidth / canvas.width)
      const contentDataURL = canvas.toDataURL('image/png')
      let pdf = new jsPDF('l', 'mm', 'a4');
      var position = 10;
      pdf.addImage(contentDataURL, 'PNG', 0 ,position,imgWidth, imgHeigth);
      pdf.save("UserHoursReport.pdf");
    })
  }
  save() {
    let relation = {
      dashboard: this.currentRelation.dashboard,
      date: this.currentRelation.date,
      time: this.currentRelation.time
    };
    this.apollo.mutate({
      mutation: CREATE_RELATION,
      variables: {
        relation: relation
      }
    }).subscribe(() => {
      this.filter();
    });
  }

}

