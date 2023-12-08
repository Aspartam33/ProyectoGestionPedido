const store = document.getElementById('store');
const barraLateral = document.querySelector('.barra-lateral');
const spans = document.querySelectorAll("span");
const menu = document.querySelector('.menu');
const main = document.querySelector('main');
menu.addEventListener("click",()=>{
  barraLateral.classList.toggle('max-barra-lateral')
  if (barraLateral.classList.contains('max-barra-lateral')) {
     menu.children[0].style.display = 'none'
     menu.children[1].style.display = 'block'
  }else{
    menu.children[0].style.display = 'block'
     menu.children[1].style.display = 'none'
  }
})
store.addEventListener("click",()=>{
  barraLateral.classList.toggle("mini-barra-lateral");
  main.classList.toggle("min-main")
  spans.forEach((span)=>{
    span.classList.toggle("oculto");
  })
})

function GetDate() {
    var now = new Date();


    var date = now.toLocaleString('es-CO')
    var time = now.getHours() + ":" + now.getMinutes() + ":" + now.getSeconds()

    document.querySelector('#datetime').textContent = "La fecha y hora es: " + date;


}

setInterval(GetDate, 1000);