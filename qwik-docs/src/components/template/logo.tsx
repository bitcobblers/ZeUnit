import { component$ } from "@builder.io/qwik"
import zeunit from '/images/zeunit.png' 
  

const Logomark = component$(() => {
    return (
      <img class="h-8 w-8" src={zeunit} height={24} width={24} />
    )
  });
  
const Logo = component$((props : { class: string}) => {
    return (        
        <span class="flex">
            <Logomark />
            <div class={props.class }  >eUnit</div>
        </span>
               
    )
  });
export { Logomark, Logo }