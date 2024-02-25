import { component$, $, useStore, useSignal} from "@builder.io/qwik"
import { Logomark } from "./logo";
import Navigation from "./navigation";
// import { Link } from "@builder.io/qwik-city";
// import { Logomark } from "./logo";

import { Modal, ModalContent } from '@qwik-ui/headless';

const MenuIcon = component$((props: any) => {
    return (
      <svg
        aria-hidden="true"
        viewBox="0 0 24 24"
        fill="none"
        strokeWidth="2"
        strokeLinecap="round"
        {...props}
      >
        <path d="M4 7h16M4 12h16M4 17h16" />
      </svg>
    )
  })
  
const CloseIcon = component$((props: any) => {
    return (
      <svg
        aria-hidden="true"
        viewBox="0 0 24 24"
        fill="none"
        strokeWidth="2"
        strokeLinecap="round"
        {...props}
      >
        <path d="M5 5l14 14M19 5l-14 14" />
      </svg>
    )
  });
  
  export default component$(() => {
    const isOpen  = useSignal(true);
        
    //  function onLinkClick(event: any) {
    //    const link = event.currentTarget
    //    if (
    //     link.pathname + link.search + link.hash ===
    //     window.location.pathname + window.location.search + window.location.hash
    //   ) {
    //     isOpen. value = false;
    //   }
    // }
    return (
      <>
        <button
          type="button"
           onClick$={$(() => { 
            console.log('clicked');
            
            isOpen.value = true;})}
          class="relative"
          aria-label="Open navigation"
        >
          <MenuIcon class="h-6 w-6 stroke-slate-500" />
        </button>        
        <CloseIcon class="h-6 w-6 stroke-slate-500" /> 
         <div hidden={!isOpen}          
          class="fixed inset-0 z-50 flex items-start overflow-y-auto bg-slate-900/50 pr-10 backdrop-blur lg:hidden"
          aria-label="Navigation"
        >
          <div class="min-h-full w-full max-w-xs bg-white px-4 pb-12 pt-5 sm:px-6 dark:bg-slate-900">
            <div class="flex items-center">
              <button
                type="button"
                onClick$={$(() => isOpen.value = false)}
                aria-label="Close navigation"
              >
                <CloseIcon class="h-6 w-6 stroke-slate-500" />
              </button>
              <a href="/" class="ml-6" aria-label="Home page">
                <Logomark class="h-9 w-9" />
              </a>
            </div>
            <Navigation />
          </div>
        </div>
      </>
    )
  });
  