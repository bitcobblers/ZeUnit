import { component$ } from "@builder.io/qwik"
import logo from '../../../public/images/zeunit.png' 
  

const Logomark = component$(() => {
    return (
      <img src={logo} height={36} width={24} />
    )
  });
  
const Logo = component$((props : { class: string}) => {
    return (        
        <span class="flex">
            <Logomark />
            <div class={props.class}>ZeUnit</div>
        </span>
               
    )
  });
export { Logomark, Logo }