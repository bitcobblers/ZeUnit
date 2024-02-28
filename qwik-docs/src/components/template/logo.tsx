import { component$ } from "@builder.io/qwik"
import zeunit from '/public/images/zeunit.png' 

const Logomark = component$(() => {
    return (
      <img class="h-10 w-10" src={zeunit} height={24} width={24} />
    )
  });
  
const Logo = component$((props : { class: string}) => {
    return (        
        <span class="flex">
            <Logomark />
            <div class={props.class }  >Unit</div>
        </span>
               
    )
  });
export { Logomark, Logo }