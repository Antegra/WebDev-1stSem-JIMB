import{_ as S,o as l,c as d,b as t,F as f,g,n as y,t as c,w as _,l as k,m as E,q as m,s as w,h as p,k as L,x as v,j as T,p as U,a as C}from"./index.0d3c77e1.js";import{A as r}from"./connection.10a8ac85.js";const N={props:{tabList:{type:Array,required:!0}},data(){return{activeTab:1,_uid:null}}},V={class:"tab"},O=["for","textContent"],P=["id","name","value"];function M(o,e,j,a,s,n){return l(),d("div",V,[t("ul",null,[(l(!0),d(f,null,g(j.tabList,(h,i)=>(l(),d("li",{key:i,class:y({li_active:i+1===s.activeTab})},[t("label",{for:`${s._uid}${i}`,textContent:c(h)},null,8,O),_(t("input",{id:`${s._uid}${i}`,type:"radio",name:`${s._uid}-tab`,value:i+1,"onUpdate:modelValue":e[0]||(e[0]=b=>s.activeTab=b)},null,8,P),[[k,s.activeTab]])],2))),128))]),(l(!0),d(f,null,g(j.tabList,(h,i)=>(l(),d(f,null,[i+1===s.activeTab?(l(),d("div",{key:i},[E(o.$slots,`tabPanel-${i+1}`,{},void 0,!0)])):m("",!0)],64))),256))])}const F=S(N,[["render",M],["__scopeId","data-v-ab24a120"]]);const x={components:{tab:F},data(){let o=localStorage.getItem("user-token"),e=JSON.parse(o);return{tabList:["Brugere","Emner","Lokationer","Uddannelser","Eksport","Profil"],users:[],user:{userModalShow:!1,modalTitle:"",user_id:0,firstName:"",lastName:"",email:"",password:"",title:"",location:"",location_id:0,edu_id:"",role_id:0,edu_name:""},subjects:[],subject:{subjectModalShow:!1,modalTitle:"",subject_id:"",name:"",description:""},locations:[],location:{locationModalShow:!1,modalTitle:"",location_id:0,name:""},educations:[],education:{educationModalShow:!1,modalTitle:"",edu_id:0,name:"",location:""},profileUsers:[],profileUser:{edu_id:[],selectedEducations:[],location_id:[],selectedLocations:[],newPassword:""},SVUserid:e[0].user_id,SVFirstName:e[0].firstName,SVLastName:e[0].lastName,SVEmail:e[0].email,SVRoleId:e[0].role_id,SVEduid:e[0].edu_id,SVEduname:e[0].edu_name,SVLocationid:e[0].location_id,SVLocation:e[0].location}},methods:{getUsers(){fetch(r+"user").then(o=>o.json()).then(o=>this.users=o)},addUser(){this.user.modalTitle="Tilf\xF8j en ny bruger",this.user.user_id=0,this.user.firstName="",this.user.lastName="",this.user.email="",this.user.password="",this.user.title="",this.user.location="",this.user.location_id=0,this.user.role_id=0,this.user.edu_id="",this.user.edu_name=""},editUser(o){this.user.modalTitle="Rediger bruger",this.user.user_id=o.user_id,this.user.firstName=o.firstName,this.user.lastName=o.lastName,this.user.email=o.email,this.user.password=o.password,this.user.title=o.title,this.user.location=o.location,this.user.location_id=o.location_id,this.user.role_id=o.role_id,this.user.edu_id=o.edu_id,this.user.edu_name=o.edu_name},async createUser(){let o=0,e=this.user.edu_id.split(","),j=[];for(let a=0;a<e.length;a++)j.push(Number(e[a]));await fetch(r+"User/",{method:"POST",headers:{"Content-Type":"application/json"},body:JSON.stringify({user_id:this.user.user_id,firstName:this.user.firstName,lastName:this.user.lastName,email:this.user.email,password:this.user.password,title:this.user.title,location:"string",location_id:"string",role_id:this.user.role_id,edu_id:"string",edu_name:"string"})}).then(a=>a.json()).then(a=>{o=a.user_id});for(let a=0;a<e.length;a++)fetch(r+"EduUser/",{method:"POST",headers:{"Content-Type":"application/json"},body:JSON.stringify({user_id:o,edu_id:j[a]})}).then(s=>s.json());fetch(r+"LocationUser/",{method:"POST",headers:{"Content-Type":"application/json"},body:JSON.stringify({user_id:o,location_id:this.user.location_id})}).then(a=>a.json())},updateUser(o){fetch(r+"user/"+o,{method:"PUT",headers:{"Content-Type":"application/json"},body:JSON.stringify({user_id:this.user.user_id,firstName:this.user.firstName,lastName:this.user.lastName,email:this.user.email,password:this.user.password,title:this.user.title,location:this.user.location,location_id:this.user.location_id,role_id:this.user.role_id,edu_id:this.user.edu_id,edu_name:this.user.edu_name})}).then(e=>{e.json(),this.getUsers()})},deleteUser(o){!confirm("Er du sikker p\xE5 at du vil slette brugeren?")||fetch(r+"user/"+o,{method:"DELETE",headers:{"Content-Type":"application/json"}}).then(e=>{e.json(),this.getUsers()})},getSubjects(){fetch(r+"subject").then(o=>o.json()).then(o=>this.subjects=o)},addSubject(){this.subject.modalTitle="Tilf\xF8j et nyt emne",this.subject.subject_id=0,this.subject.name="",this.subject.description=""},editSubject(o){this.subject.modalTitle="Rediger emne",this.subject.subject_id=o.subject_id,this.subject.name=o.name,this.subject.description=o.description},createSubject(){fetch(r+"subject/",{method:"POST",headers:{"Content-Type":"application/json"},body:JSON.stringify({subject_id:this.subject.subject_id,name:this.subject.name,description:this.subject.description})}).then(o=>{o.json(),this.getSubjects()})},updateSubject(o){fetch(r+"subject/"+o,{method:"PUT",headers:{"Content-Type":"application/json"},body:JSON.stringify({subject_id:this.subject.subject_id,name:this.subject.name,description:this.subject.description})}).then(e=>{e.json(),this.getSubjects()})},deleteSubject(o){!confirm("Er du sikker p\xE5 at du vil slette emnet?")||fetch(r+"subject/"+o,{method:"DELETE",headers:{"Content-Type":"application/json"}}).then(e=>{e.json(),this.getSubjects()})},getLocations(){fetch(r+"location").then(o=>o.json()).then(o=>this.locations=o)},addLocation(){this.location.modalTitle="Tilf\xF8j en ny lokation",this.location.location_id=0,this.location.name=""},editLocation(o){this.location.modalTitle="Rediger lokation",this.location.location_id=o.location_id,this.location.name=o.name},createLocation(){fetch(r+"location/",{method:"POST",headers:{"Content-Type":"application/json"},body:JSON.stringify({location_id:this.location.location_id,name:this.location.name})}).then(o=>{o.json(),this.getLocations()})},updateLocation(o){fetch(r+"location/"+o,{method:"PUT",headers:{"Content-Type":"application/json"},body:JSON.stringify({location_id:this.location.location_id,name:this.location.name})}).then(e=>{e.json(),this.getLocations()})},deleteLocation(o){!confirm("Er du sikker p\xE5 at du vil slette lokationen?")||fetch(r+"location/"+o,{method:"DELETE",headers:{"Content-Type":"application/json"}}).then(e=>{e.json(),this.getLocations()})},getEducations(){fetch(r+"education").then(o=>o.json()).then(o=>this.educations=o)},addEducation(){this.education.modalTitle="Tilf\xF8j en ny uddannelse",this.education.edu_id=0,this.education.name="",this.education.location=""},editEducation(o){this.education.modalTitle="Rediger uddannelse",this.education.edu_id=o.edu_id,this.education.name=o.name,this.education.location=o.location},createEducation(){fetch(r+"education/",{method:"POST",headers:{"Content-Type":"application/json"},body:JSON.stringify({edu_id:this.education.edu_id,name:this.education.name,location:this.education.location})}).then(o=>{o.json(),this.getEducations()})},updateEducation(o){fetch(r+"education/"+o,{method:"PUT",headers:{"Content-Type":"application/json"},body:JSON.stringify({edu_id:this.education.edu_id,name:this.education.name,location:this.education.location})}).then(e=>{e.json(),this.getEducations()})},deleteEducation(o){!confirm("Er du sikker p\xE5 at du vil slette uddannelsen?")||fetch(r+"education/"+o,{method:"DELETE",headers:{"Content-Type":"application/json"}}).then(e=>{e.json(),this.getEducations()})},logOut(){localStorage.removeItem("user-token"),window.location.href="/"},getFavEducation(){let o=this.SVEduid.split(",");for(let e=0;e<o.length;e++)this.profileUser.edu_id.push(Number(o[e]))},setFavEducation(o){if(document.getElementById("profilEducation").classList.contains("selected")){let a=this.profileUser.selectedEducations;a.push(o);let s=this.SVUserid,n=o+", "+s;for(let h=0;h<a.length;h++)fetch(r+"EduUser/"+n,{method:"DELETE",headers:{"Content-Type":"application/json"}}).then(i=>{i.json(),this.getEducations(),confirm("Du har nu \xE6ndret din din favorrit uddannelse og skal logge ind igen.")&&this.logOut()})}else{let a=this.profileUser.selectedEducations;a.push(o);let s=this.SVUserid;for(let n=0;n<a.length;n++)fetch(r+"EduUser",{method:"POST",headers:{"Content-Type":"application/json"},body:JSON.stringify({user_id:s,edu_id:a[0]})}).then(h=>{h.json(),this.getEducations(),confirm("Du har nu \xE6ndret din din favorrit uddannelse og skal logge ind igen.")&&this.logOut()})}},getFavLocation(){let o=this.SVLocationid.split(",");for(let e=0;e<o.length;e++)this.profileUser.location_id.push(Number(o[e]))},setFavLocation(o){if(document.getElementById("profilLocation").classList.contains("selected")){let a=this.profileUser.selectedLocations;a.push(o);let s=this.SVUserid,n=o+", "+s;for(let h=0;h<a.length;h++)fetch(r+"LocationUser/"+n,{method:"DELETE",headers:{"Content-Type":"application/json"}}).then(i=>{i.json(),this.getLocations(),confirm("Du har nu \xE6ndret din din lokation og skal logge ind igen.")&&this.logOut()})}else{let a=this.profileUser.selectedLocations;a.push(o);let s=this.SVUserid;for(let n=0;n<a.length;n++)fetch(r+"api/LocationUser",{method:"POST",headers:{"Content-Type":"application/json"},body:JSON.stringify({user_id:s,location_id:a[0]})}).then(h=>{h.json(),this.getLocations(),confirm("Du har nu \xE6ndret din lokation og skal logge ind igen.")&&this.logOut()})}},updatePassword(o){fetch(r+"user/"+o,{method:"PUT",headers:{"Content-Type":"application/json"},body:JSON.stringify({user_id:o,firstName:this.SVFirstName,lastName:this.SVLastName,email:this.SVEmail,password:this.newPassword,title:"",location:this.SVLocation,location_id:this.SVLocationid,role_id:this.SVRoleId,edu_id:this.SVEduid,edu_name:this.SVEduname})}).then(e=>{e.json(),this.getUsers(),confirm("Du har nu \xE6ndret din adgangskode og skal logge ind igen.")&&this.logOut()})}},beforeMount(){this.getUsers(),this.getSubjects(),this.getLocations(),this.getEducations(),this.getFavEducation(),this.getFavLocation()}},u=o=>(U("data-v-1bc6224a"),o=o(),C(),o),J={class:"settings"},D={key:0,class:"modal"},R={class:"modal-container"},I={class:"modal-title"},B={class:"modal-content"},A={class:"input-container"},q=u(()=>t("span",null,"Fornavn",-1)),H={class:"input-container"},z=u(()=>t("span",null,"Efternavn",-1)),G={class:"input-container"},K=u(()=>t("span",null,"Email",-1)),Q={class:"input-container"},W=u(()=>t("span",null,"Role id",-1)),X={class:"input-container"},Y=u(()=>t("span",null,"Password",-1)),Z={class:"input-container"},$=u(()=>t("span",null,"Education id",-1)),tt={class:"input-container"},et=u(()=>t("span",null,"Location id",-1)),st={class:"action-container"},ot={key:1,class:"modal"},it={class:"modal-container"},nt={class:"modal-title"},lt={class:"modal-content"},dt={class:"input-container"},at=u(()=>t("span",null,"Name",-1)),ut={class:"input-container"},rt=u(()=>t("span",null,"Hj\xE6lpebeskrivelse",-1)),ct={class:"action-container"},ht={key:2,class:"modal"},_t={class:"modal-container"},pt={class:"modal-title"},mt={class:"modal-content"},bt={class:"input-container"},ft=u(()=>t("span",null,"Name",-1)),jt={class:"action-container"},gt={key:3,class:"modal"},vt={class:"modal-container"},yt={class:"modal-title"},St={class:"modal-content"},kt={class:"input-container"},Et=u(()=>t("span",null,"Name",-1)),wt={class:"input-container"},Lt=u(()=>t("span",null,"Sted",-1)),Tt={class:"action-container"},Ut={class:"settings-container"},Ct={class:"header"},Nt=u(()=>t("h2",null,"Brugere",-1)),Vt=u(()=>t("thead",null,[t("tr",null,[t("th",null,"Fornavn"),t("th",null,"Efternavn"),t("th",null,"Email"),t("th",null,"Brugerrolle"),t("th",null,"Rediger/slet")])],-1)),Ot={class:"edit_save"},Pt=["onClick"],Mt={class:"header"},Ft=u(()=>t("h2",null,"Emner",-1)),xt=u(()=>t("thead",null,[t("tr",null,[t("th",null,"Navn"),t("th",null,"Hj\xE6lpebeskrivelse"),t("th",null,"Rediger/slet")])],-1)),Jt={class:"edit_save"},Dt=["onClick"],Rt={class:"header"},It=u(()=>t("h2",null,"Lokationer",-1)),Bt=u(()=>t("thead",null,[t("tr",null,[t("th",null,"Navn"),t("th",null,"Rediger/slet")])],-1)),At={class:"edit_save"},qt=["onClick"],Ht={class:"header"},zt=u(()=>t("h2",null,"Uddannelser",-1)),Gt=u(()=>t("thead",null,[t("tr",null,[t("th",null,"Navn"),t("th",null,"Sted"),t("th",null,"Rediger/slet")])],-1)),Kt={class:"edit_save"},Qt=["onClick"],Wt=u(()=>t("div",{class:"header"},[t("h2",null,"Profil")],-1)),Xt={class:"educations"},Yt=u(()=>t("h3",null,"V\xE6lg faste uddannelser",-1)),Zt={class:"education-grid"},$t=["onClick"],te={class:"locations"},ee=u(()=>t("h3",null,"V\xE6lg prim\xE6re uddannelsesteder",-1)),se={class:"location-grid"},oe=["onClick"],ie={class:"password"},ne=u(()=>t("h3",null,"\xC6ndre din adgangskode",-1)),le={class:"password-wrapper"};function de(o,e,j,a,s,n){const h=w("tab");return l(),d("div",J,[s.user.userModalShow?(l(),d("div",D,[t("div",R,[t("h2",I,c(s.user.modalTitle),1),t("div",B,[t("div",A,[q,_(t("input",{type:"text","onUpdate:modelValue":e[0]||(e[0]=i=>s.user.firstName=i)},null,512),[[p,s.user.firstName]])]),t("div",H,[z,_(t("input",{type:"text","onUpdate:modelValue":e[1]||(e[1]=i=>s.user.lastName=i)},null,512),[[p,s.user.lastName]])]),t("div",G,[K,_(t("input",{type:"text","onUpdate:modelValue":e[2]||(e[2]=i=>s.user.email=i)},null,512),[[p,s.user.email]])]),t("div",Q,[W,_(t("input",{type:"text","onUpdate:modelValue":e[3]||(e[3]=i=>s.user.role_id=i)},null,512),[[p,s.user.role_id]])]),t("div",X,[Y,_(t("input",{type:"text","onUpdate:modelValue":e[4]||(e[4]=i=>s.user.password=i)},null,512),[[p,s.user.password]])]),t("div",Z,[$,_(t("input",{type:"text","onUpdate:modelValue":e[5]||(e[5]=i=>s.user.edu_id=i)},null,512),[[p,s.user.edu_id]])]),t("div",tt,[et,_(t("input",{type:"number","onUpdate:modelValue":e[6]||(e[6]=i=>s.user.location_id=i)},null,512),[[p,s.user.location_id]])])]),t("div",st,[s.user.user_id==0?(l(),d("button",{key:0,class:"yellow-button",onClick:e[7]||(e[7]=i=>(n.createUser(),s.user.userModalShow=!1))}," Opret ")):m("",!0),s.user.user_id!=0?(l(),d("button",{key:1,class:"yellow-button",onClick:e[8]||(e[8]=i=>(n.updateUser(s.user.user_id),s.user.userModalShow=!1))}," Opdater ")):m("",!0),t("button",{onClick:e[9]||(e[9]=i=>s.user.userModalShow=!1)},"Luk")])])])):m("",!0),s.subject.subjectModalShow?(l(),d("div",ot,[t("div",it,[t("h2",nt,c(s.subject.modalTitle),1),t("div",lt,[t("div",dt,[at,_(t("input",{type:"text","onUpdate:modelValue":e[10]||(e[10]=i=>s.subject.name=i)},null,512),[[p,s.subject.name]])]),t("div",ut,[rt,_(t("textarea",{"onUpdate:modelValue":e[11]||(e[11]=i=>s.subject.description=i)},null,512),[[p,s.subject.description]])])]),t("div",ct,[s.subject.subject_id==0?(l(),d("button",{key:0,class:"yellow-button",onClick:e[12]||(e[12]=i=>(n.createSubject(),s.subject.subjectModalShow=!1))}," Opret ")):m("",!0),s.subject.subject_id!=0?(l(),d("button",{key:1,class:"yellow-button",onClick:e[13]||(e[13]=i=>(n.updateSubject(s.subject.subject_id),s.subject.subjectModalShow=!1))}," Opdater ")):m("",!0),t("button",{onClick:e[14]||(e[14]=i=>s.subject.subjectModalShow=!1)},"Luk")])])])):m("",!0),s.location.locationModalShow?(l(),d("div",ht,[t("div",_t,[t("h2",pt,c(s.location.modalTitle),1),t("div",mt,[t("div",bt,[ft,_(t("input",{type:"text","onUpdate:modelValue":e[15]||(e[15]=i=>s.location.name=i)},null,512),[[p,s.location.name]])])]),t("div",jt,[s.location.location_id==0?(l(),d("button",{key:0,class:"yellow-button",onClick:e[16]||(e[16]=i=>(n.createLocation(),s.location.locationModalShow=!1))}," Opret ")):m("",!0),s.location.location_id!=0?(l(),d("button",{key:1,class:"yellow-button",onClick:e[17]||(e[17]=i=>(n.updateLocation(s.location.location_id),s.location.locationModalShow=!1))}," Opdater ")):m("",!0),t("button",{onClick:e[18]||(e[18]=i=>s.location.locationModalShow=!1)},"Luk")])])])):m("",!0),s.education.educationModalShow?(l(),d("div",gt,[t("div",vt,[t("h2",yt,c(s.education.modalTitle),1),t("div",St,[t("div",kt,[Et,_(t("input",{type:"text","onUpdate:modelValue":e[19]||(e[19]=i=>s.education.name=i)},null,512),[[p,s.education.name]])]),t("div",wt,[Lt,_(t("input",{type:"text","onUpdate:modelValue":e[20]||(e[20]=i=>s.education.location=i)},null,512),[[p,s.education.location]])])]),t("div",Tt,[s.education.edu_id==0?(l(),d("button",{key:0,class:"yellow-button",onClick:e[21]||(e[21]=i=>(n.createEducation(),s.education.educationModalShow=!1))}," Opret ")):m("",!0),s.education.edu_id!=0?(l(),d("button",{key:1,class:"yellow-button",onClick:e[22]||(e[22]=i=>(n.updateEducation(s.education.edu_id),s.education.educationModalShow=!1))}," Opdater ")):m("",!0),t("button",{onClick:e[23]||(e[23]=i=>s.education.educationModalShow=!1)},"Luk")])])])):m("",!0),t("div",Ut,[L(h,{tabList:s.tabList},{"tabPanel-1":v(()=>[t("div",Ct,[Nt,t("button",{class:"yellow-button-tab",onClick:e[24]||(e[24]=i=>(n.addUser(s.user),s.user.userModalShow=!0))}," Tilf\xF8j en ny bruger ")]),t("table",null,[Vt,t("tbody",null,[(l(!0),d(f,null,g(s.users,i=>(l(),d("tr",{key:i.user_id},[t("td",null,[t("p",null,c(i.firstName),1)]),t("td",null,[t("p",null,c(i.lastName),1)]),t("td",null,[t("p",null,c(i.email),1)]),t("td",null,c(i.title),1),t("td",Ot,[t("button",{class:"edit-btn",onClick:b=>(n.editUser(i),s.user.userModalShow=!0)},null,8,Pt),t("button",{class:"delete",onClick:e[25]||(e[25]=b=>n.deleteUser(s.user.user_id))})])]))),128))])])]),"tabPanel-2":v(()=>[t("div",Mt,[Ft,t("button",{class:"yellow-button-tab",onClick:e[26]||(e[26]=i=>(n.addSubject(o.s),s.subject.subjectModalShow=!0))}," Tilf\xF8j et nyt emne ")]),t("table",null,[xt,t("tbody",null,[(l(!0),d(f,null,g(s.subjects,i=>(l(),d("tr",{key:i.subject_id},[t("td",null,[t("p",null,c(i.name),1)]),t("td",null,[t("p",null,c(i.description),1)]),t("td",Jt,[t("button",{class:"edit-btn",onClick:b=>(n.editSubject(i),s.subject.subjectModalShow=!0)},null,8,Dt),t("button",{class:"delete",onClick:e[27]||(e[27]=b=>n.deleteSubject(s.subject.subject_id))})])]))),128))])])]),"tabPanel-3":v(()=>[t("div",Rt,[It,t("button",{class:"yellow-button-tab",onClick:e[28]||(e[28]=i=>(n.addLocation(s.location),s.location.locationModalShow=!0))}," Tilf\xF8j en ny lokation ")]),t("table",null,[Bt,t("tbody",null,[(l(!0),d(f,null,g(s.locations,i=>(l(),d("tr",{key:i.location_id},[t("td",null,[t("p",null,c(i.name),1)]),t("td",At,[t("button",{class:"edit-btn",onClick:b=>(n.editLocation(i),s.location.locationModalShow=!0)},null,8,qt),t("button",{class:"delete",onClick:e[29]||(e[29]=b=>n.deleteLocation(s.location.location_id))})])]))),128))])])]),"tabPanel-4":v(()=>[t("div",Ht,[zt,t("button",{class:"yellow-button-tab",onClick:e[30]||(e[30]=i=>(n.addEducation(s.education),s.education.educationModalShow=!0))}," Tilf\xF8j en ny uddannelse ")]),t("table",null,[Gt,t("tbody",null,[(l(!0),d(f,null,g(s.educations,i=>(l(),d("tr",{key:i.edu_id},[t("td",null,[t("p",null,c(i.name),1)]),t("td",null,[t("p",null,c(i.location),1)]),t("td",Kt,[t("button",{class:"edit-btn",onClick:b=>(n.editEducation(i),s.education.educationModalShow=!0)},null,8,Qt),t("button",{class:"delete",onClick:e[31]||(e[31]=b=>n.deleteEducation(s.education.edu_id))})])]))),128))])])]),"tabPanel-5":v(()=>[T(" Eksporter data ")]),"tabPanel-6":v(()=>[Wt,t("div",Xt,[Yt,t("div",Zt,[(l(!0),d(f,null,g(s.educations,i=>(l(),d("button",{id:"profilEducation",key:i.edu_id,onClick:b=>n.setFavEducation(i.edu_id),class:y({selected:this.profileUser.edu_id.includes(i.edu_id)})},c(i.name),11,$t))),128))])]),t("div",te,[ee,t("div",se,[(l(!0),d(f,null,g(s.locations,i=>(l(),d("button",{id:"profilLocation",key:s.location.location_id,onClick:b=>n.setFavLocation(i.location_id),class:y({selected:this.profileUser.location_id.includes(i.location_id)})},c(i.name),11,oe))),128))])]),t("div",ie,[ne,t("div",le,[_(t("input",{type:"text","onUpdate:modelValue":e[32]||(e[32]=i=>o.newPassword=i),id:"passwordField"},null,512),[[p,o.newPassword]]),t("button",{class:"yellow-button-tab",onClick:e[33]||(e[33]=i=>n.updatePassword(this.SVUserid))},"Gem adgangskode")])])]),_:1},8,["tabList"])])])}const re=S(x,[["render",de],["__scopeId","data-v-1bc6224a"]]);export{re as default};
