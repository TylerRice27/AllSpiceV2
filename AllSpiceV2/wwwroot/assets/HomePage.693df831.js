import{_ as g,d as v,r as i,l as a,P as c,b as l,f as y,c as d,a as s,F as m,e as f,o as n,g as u,A as p,h as w}from"./index.6f8094c5.js";const R={setup(){return v(async()=>{try{await i.getRecipes()}catch(e){a.error(e),c.toast(e.message,"error")}}),{recipes:l(()=>p.recipes),account:l(()=>p.account),async getRecipes(){try{await i.getRecipes()}catch(e){a.error(e),c.toast(e.message,"error")}},async getFavorites(){try{await y.getFavorites()}catch(e){a.error(e),c.toast(e.message,"error")}},async getMyRecipes(){try{await i.getMyRecipes()}catch(e){a.error(e),c.toast(e.message,"error")}}}}},x={class:"container-fluid"},h={class:"row justify-content-center"},k={class:"card glass2 elevation-5 d-flex flex-row justify-content-evenly align-items-center ty"},F={class:"row"};function M(e,t,b,o,B,C){const _=w("Recipe");return n(),d("div",x,[s("div",h,[s("div",k,[s("div",{class:"selectable text-white",onClick:t[0]||(t[0]=r=>o.getRecipes())},"Home"),s("div",{class:"selectable text-white",onClick:t[1]||(t[1]=r=>o.getMyRecipes())}," My Recipes "),s("div",{class:"selectable text-white",onClick:t[2]||(t[2]=r=>o.getFavorites())}," Favorites ")])]),s("div",F,[(n(!0),d(m,null,f(o.recipes,r=>(n(),u(_,{key:r.id,recipe:r},null,8,["recipe"]))),128))])])}const H=g(R,[["render",M],["__scopeId","data-v-df034151"]]);export{H as default};